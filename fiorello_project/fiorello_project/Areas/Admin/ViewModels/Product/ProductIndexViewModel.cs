using fiorello_project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace fiorello_project.Areas.Admin.ViewModels.Product
{
    public class ProductIndexViewModel
    {

        public List<Models.Product> Products { get; set; }

        #region Filter

        public string? Title { get; set; }
        public List<SelectListItem> Categories { get; set; }

        [Display(Name ="Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Minimum Price")]
        public double? MinPrice { get; set; }


        [Display(Name = "Maximum Price")]
        public double? MaxPrice { get; set; }


        [Display(Name = "Minimum Quantity")]
        public int? MinQuantity { get; set; }

        [Display(Name = "Maximum Quantity")]
        public int? MaxQuantity { get; set; }

        [Display(Name = "Created start date")]
        public DateTime? CreateAtStart { get; set; }


        [Display(Name = "Created end date")]
        public DateTime? CreateAtEnd { get; set; }

        public ProductStatus? Status { get; set; }

        #endregion

    }
}
