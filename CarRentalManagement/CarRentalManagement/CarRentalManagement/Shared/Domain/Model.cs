using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Shared.Domain
{
    public class Model : Base
    {
        [Required(ErrorMessage = "Enter car model")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Car model does not meet the length requirements.")]
        public string Name { get; set; }
    }
}
