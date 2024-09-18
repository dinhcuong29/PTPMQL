using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demomvc.Models
{
    [Table("Hệ Thống Phân Phối")]
    public class HeThongPhanPhoi
    {
    [Key]
    public string MaHTPP{get;set;}
    public string TenHTPP{get;set;}
    }
}