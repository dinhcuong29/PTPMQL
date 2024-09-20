using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demomvc.Models
{
    [Table("Đại Lý")]
public class DaiLy
{
    [Key]
    public string MaDaiLy{get;set;}
    public string TenDaiLy{get;set;}
    public string DiaChi{get;set;}
    public string NguoiDaiDien{get;set;}
    public string DienThoai{get;set;}
    public string MaHTPP{get;set;}
}
}