using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    /// <summary>
    /// 学生类
    /// </summary>

    public class Student
    {
        public int Id { get; set; }
        public string StudentId { get; set; } = "";
        public string Name { get; set; } = "";
        public string Gender { get; set; } = "";
        public int Age { get; set; }
        public string Class { get; set; } = "";
        public string Department { get; set; } = "";
        public string Major { get; set; } = "";
    }
}
