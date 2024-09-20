using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demomvc.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public string StudentID{get;set;}
        public string Fullname{get;set;}
        public string Address{get;set;}
    }
}