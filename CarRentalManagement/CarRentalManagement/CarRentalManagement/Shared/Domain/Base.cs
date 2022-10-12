using System;

namespace CarRentalManagement.Shared.Domain
{
    public abstract class Base
    {
        public Guid Id { get; init; }

        public DateTime DateCreated { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime DateUpdated { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
