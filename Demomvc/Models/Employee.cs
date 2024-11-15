using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demomvc.Models
{
    public class Employee : Person
    {
        public required string EmployeeID{get;set;}
        public string? Company{ get; set; }
    }
}