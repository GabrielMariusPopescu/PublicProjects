using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Shared.Domain
{
    public class Rental : Base, IValidatableObject
    {
        public Guid VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        [Required(ErrorMessage = "Enter the date of the rent")]
        [DataType(DataType.Date, ErrorMessage = "Date of the rent does not meet requirements.")]
        public DateTime DateOut { get; set; }

        public DateTime? DateIn { get; set; }

        public virtual Customer Customer { get; set; }

        public Guid CustomerId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateIn <= DateOut)
            {
                yield return new ValidationResult("Return date must be greater than rent date", new[] { "DateIn" });
            }
        }
    }
}