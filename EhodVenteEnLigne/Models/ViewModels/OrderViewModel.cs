using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EhodBoutiqueEnLigne.Models.ViewModels
{
    public class OrderViewModel
    {
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your address")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your city")]

        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your zip code")]
        
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }
            [BindNever]
        public DateTime Date { get; set; }
    }
}
