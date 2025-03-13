using System;
using System.ComponentModel;

namespace GenerateCode
{
    /// <summary>
    /// 班级实体类
    /// </summary>
    [Description("班级实体")]
    public class ClassInfo
    {
        /// <summary>
        /// 班级编号
        /// </summary>
        [Description("班级编号")]
        public string? ClassNumber { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        [Description("班级名称")]
        public string? ClassName { get; set; }

        /// <summary>
        /// 班主任
        /// </summary>
        [Description("班主任")]
        public string? HeadTeacher { get; set; }

        /// <summary>
        /// 学生人数
        /// </summary>
        [Description("学生人数")]
        public int StudentCount { get; set; }

        /// <summary>
        /// 所属年级
        /// </summary>
        [Description("所属年级")]
        public string? Grade { get; set; }

        /// <summary>
        /// 教室位置
        /// </summary>
        [Description("教室位置")]
        public string? ClassroomLocation { get; set; }
    }
}