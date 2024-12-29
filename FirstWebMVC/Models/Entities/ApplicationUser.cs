using Microsoft.AspNetCore.Identity;

namespace FirstWebMVC.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }
    }
}
