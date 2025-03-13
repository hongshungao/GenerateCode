using System;
using System.ComponentModel;

namespace GenerateCode
{


    /// <summary>
    //"班级实体"
    /// </summary>
    [Description("班级实体")]
    public class ClassInfoDto
    {
         /// <summary>
         ///"班级编号"
         /// </summary>
        public string? ClassNumber { get; set; }
         /// <summary>
         ///"班级名称"
         /// </summary>
        public string? ClassName { get; set; }
         /// <summary>
         ///"班主任"
         /// </summary>
        public string? HeadTeacher { get; set; }
         /// <summary>
         ///"学生人数"
         /// </summary>
        public int StudentCount { get; set; }
         /// <summary>
         ///"所属年级"
         /// </summary>
        public string? Grade { get; set; }
         /// <summary>
         ///"教室位置"
         /// </summary>
        public string? ClassroomLocation { get; set; }
    }


      /// <summary>
    //"班级实体"
    /// </summary>
    [Description("班级实体")]
    public class ClassInfoCreateDto
    {
         /// <summary>
         ///"班级编号"
         /// </summary>
        public string? ClassNumber { get; set; }
         /// <summary>
         ///"班级名称"
         /// </summary>
        public string? ClassName { get; set; }
         /// <summary>
         ///"班主任"
         /// </summary>
        public string? HeadTeacher { get; set; }
         /// <summary>
         ///"学生人数"
         /// </summary>
        public int StudentCount { get; set; }
         /// <summary>
         ///"所属年级"
         /// </summary>
        public string? Grade { get; set; }
         /// <summary>
         ///"教室位置"
         /// </summary>
        public string? ClassroomLocation { get; set; }
    }

       /// <summary>
    //"班级实体"
    /// </summary>
    [Description("班级实体")]
    public class ClassInfoUpdateDto
    {
         /// <summary>
         ///"班级编号"
         /// </summary>
        public string? ClassNumber { get; set; }
         /// <summary>
         ///"班级名称"
         /// </summary>
        public string? ClassName { get; set; }
         /// <summary>
         ///"班主任"
         /// </summary>
        public string? HeadTeacher { get; set; }
         /// <summary>
         ///"学生人数"
         /// </summary>
        public int StudentCount { get; set; }
         /// <summary>
         ///"所属年级"
         /// </summary>
        public string? Grade { get; set; }
         /// <summary>
         ///"教室位置"
         /// </summary>
        public string? ClassroomLocation { get; set; }
    }
}