namespace CarRentalManagement.Server.Configurations.Entities;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "FE8F0D0D-E180-4C7E-B9DC-FD13576C1FB8",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new IdentityRole
            {
                Id = "781624CC-A913-4F96-9E71-5E2B95E0C05F",
                Name = "User",
                NormalizedName = "USER"
            });
    }
}