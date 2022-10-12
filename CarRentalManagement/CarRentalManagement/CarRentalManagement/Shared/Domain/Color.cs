using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Shared.Domain
{
    public class Color : Base
    {
        [Required(ErrorMessage = "Enter car color")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Car color does not meet the length requirements.")]
        public string Name { get; set; }
    }
}
