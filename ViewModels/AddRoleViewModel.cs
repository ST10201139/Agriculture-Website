using System.ComponentModel.DataAnnotations;

namespace AgriConnectPlatformProject.ViewModels
{
    public class AddRoleViewModel
    {
       

            [Required]
            [Display(Name = "Role ")]
            public string RoleName { get; set; }
        
    }
}
