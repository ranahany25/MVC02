using System.ComponentModel.DataAnnotations;

namespace MVC02.ViewModels
{
    public class UpdateViewModel
    {
        [Display(Name ="Plan")]
        public string PlanName { get; set; } = default!;
        [Required(ErrorMessage = "Description  Is Required")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Description Must Be Between 5 and 200 chars")]
        public string Description { get; set; } = default!;
        [Required(ErrorMessage = "DurationDays  Is Required")]
        [Range(1, 365, ErrorMessage = "Duration Must be between 1 and 365 days")]
        [Display(Name = "Duration(days)")]
        public int DurationDays { get; set; }
        [Required(ErrorMessage = "Price  Is Required")]
        [Range(0.01, 10000, ErrorMessage = "Price Must Be Greater than 0")]
        [Display(Name = "Price(EGP)")]
        public decimal Price { get; set; }
    }
}
