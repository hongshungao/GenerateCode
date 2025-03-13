
using GenerateCode.GenerateHelper;

namespace UnitTests
{
    public class RoslynCodeHelperTests : IDisposable
    {
        private const string TestDataPath = "TestData";

        public RoslynCodeHelperTests()
        {
            if (!Directory.Exists(TestDataPath))
            {
                Directory.CreateDirectory(TestDataPath);
            }
        }

        [Fact]
        public void GenerateCode_ValidInput_GeneratesCode()
        {
            // Arrange
            var templatePath = Path.Combine(TestDataPath, "TestTemplate.txt");
            var entityClassPath = Path.Combine(TestDataPath, "TestEntity.cs");
            var outputDirectory = Path.Combine(TestDataPath, "Output");

            File.WriteAllText(templatePath, "Template content");
            File.WriteAllText(entityClassPath, "public class TestEntity { public string Name { get; set; } }");

            // Act
            RoslynCodeHelper.GenerateCode(templatePath, entityClassPath, outputDirectory);

            // Assert
            var outputFile = Path.Combine(outputDirectory, "TestEntityService.cs");
            Assert.True(File.Exists(outputFile));
        }

        [Fact]
        public void GenerateCode_InvalidTemplatePath_ThrowsException()
        {
            // Arrange
            var invalidTemplatePath = Path.Combine(TestDataPath, "InvalidTemplate.txt");
            var entityClassPath = Path.Combine(TestDataPath, "TestEntity.cs");
            var outputDirectory = Path.Combine(TestDataPath, "Output");

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => RoslynCodeHelper.GenerateCode(invalidTemplatePath, entityClassPath, outputDirectory));
        }

    

        public void Dispose()
        {
            if (Directory.Exists(TestDataPath))
            {
                Directory.Delete(TestDataPath, true);
            }
        }
    }
}