using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Scriban;
using Scriban.Runtime;

namespace GenerateCode.GenerateHelper
{
    public static class RoslynCodeHelper
    {
        public static void GenerateCode(string templatePath, string entityClassPath, string outputDirectory)
        {
            ValidatePaths(templatePath, outputDirectory);
            var syntaxTree = ParseEntityClass(entityClassPath);
            var properties = GetEntityProperties(syntaxTree);
            var template = LoadTemplate(templatePath);
            var result = RenderTemplate(template, syntaxTree, properties);
            WriteOutput(outputDirectory, syntaxTree, result);
        }

        private static void ValidatePaths(string templatePath, string outputDirectory)
        {
            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"未找到模板文件: {templatePath}");
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
        }

        private static SyntaxTree ParseEntityClass(string entityClassPath)
        {
            if (!File.Exists(entityClassPath))
            {
                throw new FileNotFoundException($"未找到实体类文件: {entityClassPath}");
            }
            var code = File.ReadAllText(entityClassPath);
            return CSharpSyntaxTree.ParseText(code);
        }

        private static List<object> GetEntityProperties(SyntaxTree syntaxTree)
        {
            var root = syntaxTree.GetRoot();
            var classDeclaration = root.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();

            if (classDeclaration == null)
            {
                throw new Exception($"未找到实体类");
            }

            return classDeclaration.Members
                .OfType<PropertyDeclarationSyntax>()
                .Select(p => (object)new
                {
                    Name = p.Identifier.Text,
                    Type = p.Type.ToString(),
                    Description = p.GetLeadingTrivia()
                        .Select(t => t.GetStructure())
                        .OfType<DocumentationCommentTriviaSyntax>()
                        .SelectMany(d => d.ChildNodes())
                        .OfType<XmlElementSyntax>()
                        .FirstOrDefault(x => x.StartTag.Name.ToString() == "summary")?
                        .Content.ToString()
                        .Trim() ?? ""
                })
                .ToList();
        }

        private static Template LoadTemplate(string templatePath)
        {
            var templateContent = File.ReadAllText(templatePath);
            return Template.Parse(templateContent);
        }

        private static string RenderTemplate(Template template, SyntaxTree syntaxTree, List<object> properties)
        {
            var root = syntaxTree.GetRoot();
            var classDeclaration = root.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();

            var scriptObject = new ScriptObject();
            scriptObject.Import(typeof(RoslynCodeHelper));
            scriptObject["EntityName"] = classDeclaration?.Identifier.Text;
            scriptObject["Description"] = classDeclaration?.GetLeadingTrivia()
                .Select(t => t.GetStructure())
                .OfType<DocumentationCommentTriviaSyntax>()
                .SelectMany(d => d.ChildNodes())
                .OfType<XmlElementSyntax>()
                .FirstOrDefault(x => x.StartTag.Name.ToString() == "summary")?
                .Content.ToString()
                .Trim() ?? "";
            scriptObject["Properties"] = properties;

            var context = new TemplateContext();
            context.PushGlobal(scriptObject);

            return template.Render(context);
        }

        private static void WriteOutput(string outputDirectory, SyntaxTree syntaxTree, string result)
        {
            var root = syntaxTree.GetRoot();
            var classDeclaration = root.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
            var outputPath = Path.Combine(outputDirectory, $"{classDeclaration?.Identifier.Text}Service.cs");
            File.WriteAllText(outputPath, result);
        }
    }
}