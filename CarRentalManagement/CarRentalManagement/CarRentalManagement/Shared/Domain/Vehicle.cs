using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagement.Shared.Domain
{
    public class Vehicle : Base
    {
        [Required(ErrorMessage = "Enter Car Year")]
        public int Year { get; set; }

        public Guid ModelId { get; set; }

        public virtual Model Model { get; set; }

        public Guid BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public Guid ColorId { get; set; }

        public virtual Color Color { get; set; }

        [Required(ErrorMessage = "Enter Vehicle Identification Number")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "VIN does not meet the length requirements.")]
        public string Vin { get; set; }

        [Required(ErrorMessage = "Enter Plate Number")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Plate Number does not meet the length requirements.")]
        public string PlateNumber { get; set; }

        public virtual List<Rental> Rentals { get; set; }

        [Required(ErrorMessage = "Enter Rental Rate")]
        public double RentalRate { get; set; }

        [NotMapped]
        public byte[] Image { get; set; }

        public string ImageName { get; set; }
    }
}
