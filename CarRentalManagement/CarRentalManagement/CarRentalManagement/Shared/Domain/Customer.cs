using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Shared.Domain
{
    public class Customer : Base
    {
        [Required(ErrorMessage = "Enter First Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name does not meet the length requirements.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name does not meet the length requirements.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Address does not meet the length requirements.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Phone Number")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number does not meet the length requirements.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Enter Email Address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Enter Tax Id")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Tax Id does not meet the length requirements.")]
        public string TaxId { get; set; }

        public virtual List<Rental> Rentals { get; set; }
    }
}
