using System;
using System.ComponentModel;

namespace GenerateCode
{
    {{~ entity  =  EntityName ~}}
    {{~ description  =  Description ~}}


    /// <summary>
     {{description}}
    /// </summary>
    //[Description("{{description}}")]
    public class {{entity}}Dto
    {
        {{~ for prop in Properties ~}}
        {{~ Type = prop.type ~}}
        {{~ Name = prop.name ~}}
        {{~ Description = prop.description ~}}
         /// <summary>
          {{Description}}
         /// </summary>
        public {{Type}} {{Name}} { get; set; }
        {{~ end ~}}
    }


    /// <summary>
     {{description}}
    /// </summary>
    //[Description("{{description}}")]
    public class {{entity}}CreateDto
    {
        {{~ for prop in Properties ~}}
        {{~ Type = prop.type ~}}
        {{~ Name = prop.name ~}}
        {{~ Description = prop.description ~}}
         /// <summary>
          {{Description}}
         /// </summary>
        public {{Type}} {{Name}} { get; set; }
        {{~ end ~}}
    }

     /// <summary>
     {{description}}
    /// </summary>
    //[Description("{{description}}")]
    public class {{entity}}UpdateDto
    {
        {{~ for prop in Properties ~}}
        {{~ Type = prop.type ~}}
        {{~ Name = prop.name ~}}
        {{~ Description = prop.description ~}}
         /// <summary>
          {{Description}}
         /// </summary>
        public {{Type}} {{Name}} { get; set; }
        {{~ end ~}}
    }
}