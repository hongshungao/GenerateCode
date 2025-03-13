# GenerateCode
.Net 的基本代码生成器

使用框架: .Net 9.0

使用package: Microsoft.CodeAnalysis.CSharp、Scriban、xunit、xunit.runner.visualstudio

  <font color="red" >**说明：提供了 两个Helper 一个是用反射获取的实体的相关信息，另一个是用的Roslyn 语法树获取的**</font>



> 使用说明

### <font color="green">1、在项目GenerateCode下的Template文件夹下 先创建需要生成的代码模板</font>

### <font color="green">2、在Entity创建对应的Entity</font>

### <font color="green">3、通过命令运行项目，如：dotnet run Template/ABPApiTemplate.txt Entity/ClassInfo.cs output</font>

<font color="red">说明： 第一个参数是模板 第二个参数是类 第三个参数是输出到的文件夹</font>









