namespace CarRentalManagement.Server.Configurations.Entities;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                UserId = "99B7485A-20E0-4F16-8865-7112C035746C",
                RoleId = "FE8F0D0D-E180-4C7E-B9DC-FD13576C1FB8"
            },
            new IdentityUserRole<string>
            {
                UserId = "6565AAA9-8B95-447A-9540-BEEAB3A8A0F1",
                RoleId = "781624CC-A913-4F96-9E71-5E2B95E0C05F"
            });
    }
}