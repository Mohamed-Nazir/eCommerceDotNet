using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace EhodBoutiqueEnLigne.Models.ViewModels
{
    public class ProductViewModel
    {
        [BindNever]
        public int Id { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(EhodVenteEnLigne.Resources.Models.Product), ErrorMessageResourceName = "MissingName")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }

        [Required(ErrorMessageResourceType = typeof(EhodVenteEnLigne.Resources.Models.Product), ErrorMessageResourceName = "MissingQuantity")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "StockNotAnInteger")]
        public string Stock { get; set; }

        [Required(ErrorMessageResourceType = typeof(EhodVenteEnLigne.Resources.Models.Product), ErrorMessageResourceName = "MissingPrice")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "PriceNotANumber")]
        [Range(0.01, double.MaxValue, ErrorMessage = "PriceNotGreaterThanZero")]
        public string Price { get; set; }
    }
}
