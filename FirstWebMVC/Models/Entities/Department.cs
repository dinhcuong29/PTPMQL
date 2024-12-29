using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models.Entities
{
    public class Department
    {
        [Key]
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set;}

        [ForeignKey("StudentId")]
        public string? StudentId {get;set;}
        public Student? Std { get; set; }
    }
}