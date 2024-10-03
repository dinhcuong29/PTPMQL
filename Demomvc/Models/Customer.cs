using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demomvc.Models
{
    public class Customer
    {
        [Key]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Đây là phần bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên đầy đủ không được vượt quá 100 ký tự")]
        public string FullName { get; set; }

        [StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Đây là phần bắt buộc")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string Email { get; set; }
    }
}
