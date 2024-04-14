using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace EhodBoutiqueEnLigne.Models.ViewModels
{
    public class ProductViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }

        public string Details { get; set; }

        [Required(ErrorMessage ="Stock is required")]
        public string Stock { get; set; }
        
        [Required(ErrorMessage ="Price is required")]
        public string Price { get; set; }
    }
}
