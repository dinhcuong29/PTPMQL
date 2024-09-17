using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demomvc.Models
{
    [Table("Persons")]
    public class Person
    {
    [Key]
    public int PersonID {get;set;}
    public string Fullname {get;set;}
    public string Address {get;set;}
    public string Sđt {get;set;}
    }
}
