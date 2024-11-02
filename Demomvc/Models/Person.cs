using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demomvc.Models
{
    public class Person
    {
    [Key]
    [Required(ErrorMessage = "PersonID là bắt buộc.")]
    [StringLength(10, ErrorMessage = "PersonID không được dài quá 10 ký tự.")]
    public string PersonID { get; set; }

    [Required(ErrorMessage = "FullName là bắt buộc.")]
    [StringLength(50, ErrorMessage = "FullName không được dài quá 50 ký tự.")]
    public string FullName { get; set; }

    [StringLength(100, ErrorMessage = "Address không được dài quá 100 ký tự.")]
    public string? Address { get; set; }
    }
}