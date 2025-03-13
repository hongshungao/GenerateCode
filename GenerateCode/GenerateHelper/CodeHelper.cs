using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Scriban;
using Scriban.Runtime;

namespace GenerateCode.GenerateHelper
{
    public static class CodeHelper
    {
        public static void GenerateCode(string templatePath, string entityClassPath, string outputDirectory)
        {
            ValidatePaths(templatePath, outputDirectory);
            var entityType = GetEntityType(entityClassPath);
            var properties = GetEntityProperties(entityType);
            var template = LoadTemplate(templatePath);
            var result = RenderTemplate(template, entityType, properties);
            WriteOutput(outputDirectory, entityType, result);
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

        private static Type GetEntityType(string entityClassPath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var entityType = assembly.GetTypes().FirstOrDefault(t => t.Name == Path.GetFileNameWithoutExtension(entityClassPath) && t.Namespace == "GenerateCode");

            if (entityType == null)
            {
                throw new Exception($"未找到实体类: {entityClassPath}");
            }

            return entityType;
        }

        private static List<object> GetEntityProperties(Type entityType)
        {
            return entityType.GetProperties()
                .Select(p => (object)new
                {
                    Name = p.Name,
                    Type = GetPropertyTypeName(p.PropertyType),
                    Description = (p.GetCustomAttribute<DescriptionAttribute>()?.Description ?? "")
                })
                .ToList();
        }

        private static Template LoadTemplate(string templatePath)
        {
            var templateContent = File.ReadAllText(templatePath);
            return Template.Parse(templateContent);
        }

        private static string RenderTemplate(Template template, Type entityType, List<object> properties)
        {
            var scriptObject = new ScriptObject();
            scriptObject.Import(typeof(CodeHelper));
            scriptObject["EntityName"] = entityType.Name;
            scriptObject["Description"] = entityType.GetCustomAttribute<DescriptionAttribute>()?.Description ?? "";
            scriptObject["Properties"] = properties;

            var context = new TemplateContext();
            context.PushGlobal(scriptObject);

            return template.Render(context);
        }

        private static void WriteOutput(string outputDirectory, Type entityType, string result)
        {
            var outputPath = Path.Combine(outputDirectory, $"{entityType.Name}Service.cs");
            File.WriteAllText(outputPath, result);
        }

        private static string GetPropertyTypeName(Type propertyType)
        {
            if (propertyType.IsGenericType)
            {
                var genericType = propertyType.GetGenericTypeDefinition();
                var typeArguments = propertyType.GetGenericArguments()
                    .Select(GetPropertyTypeName)
                    .ToArray();
                return $"{genericType.Name}<{string.Join(",", typeArguments)}>";
            }
            return propertyType.Name;
        }
    }
}