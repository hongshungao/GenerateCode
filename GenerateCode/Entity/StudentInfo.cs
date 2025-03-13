using System;
using System.ComponentModel;

namespace GenerateCode
{
    /// <summary>
    /// 学生实体类
    /// </summary>
    [Description("学生实体")]
    public class StudentInfo
    {
        /// <summary>
        /// 学生唯一标识
        /// </summary>
        [Description("学生唯一标识")]
        public Guid Id { get; set; }
        /// <summary>
        /// 学生学号
        /// </summary>
        [Description("学生学号")]
        public string? StudentNumber { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        [Description("学生姓名")]
        public string? Name { get; set; }
        /// <summary>
        /// 学生年龄
        /// </summary>
        [Description("学生年龄")]
        public int Age { get; set; }
        /// <summary>
        /// 学生所在班级
        /// </summary>
        [Description("学生所在班级")]
        public string? Class { get; set; }
    }
}