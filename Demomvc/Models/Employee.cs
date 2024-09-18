using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demomvc.Models
{
    [Table("Employees")]
    public class Employee{
        [Key]
        public string EmployerID{get;set;}
        public string Fullname{get;set;}
        public int Age{get;set;}
    }
}