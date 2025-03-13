using System;
using System.IO;
using GenerateCode.GenerateHelper;

namespace GenerateCode
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("用法: GenerateCode <模板路径> <输出目录>");
                return;
            }

            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), args[0]);
            string entityClassPath = Path.Combine(Directory.GetCurrentDirectory(), args[1]);
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), args[2]);

            try
            {
                // CodeHelper.GenerateCode(templatePath, entityClassPath, outputDirectory);
                RoslynCodeHelper.GenerateCode(templatePath, entityClassPath, outputDirectory);
                Console.WriteLine($"代码成功生成在: {Path.Combine(outputDirectory, "GeneratedCode.cs")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"生成代码时出错: {ex.Message}");
            }
        }
    }
}
