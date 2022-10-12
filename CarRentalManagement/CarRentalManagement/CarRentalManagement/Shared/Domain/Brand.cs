using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Shared.Domain
{
    public class Brand : Base
    {
        [Required(ErrorMessage = "Enter car brand")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Car brand does not meet the length requirements.")]
        public string Name { get; set; }
    }
}
