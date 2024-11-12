using Microsoft.AspNetCore.Identity;
namespace Demomvc.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }
    }
}