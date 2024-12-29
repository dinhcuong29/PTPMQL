using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models.Entities
{
    public class Student
    {
        [Key]
        public string StudentId {get;set;}
        public string Name{get;set;}
        public string Address{get;set;}

        public ICollection<Department>? Department { get; set; }
    }
}