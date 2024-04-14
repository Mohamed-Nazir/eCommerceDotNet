using System.ComponentModel.DataAnnotations;

namespace EhodBoutiqueEnLigne.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}