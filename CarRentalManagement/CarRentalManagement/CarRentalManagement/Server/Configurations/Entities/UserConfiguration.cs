namespace CarRentalManagement.Server.Configurations.Entities;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        builder.HasData(
            new ApplicationUser
            {
                Id = "99B7485A-20E0-4F16-8865-7112C035746C",
                FirstName = "Jon",
                LastName = "Doe",
                Email = "jon.doe@test.com",
                NormalizedEmail = "JON.DOE@TEST.COM",
                EmailConfirmed = true,
                UserName = "Jon.Doe@test.com",
                NormalizedUserName = "JON.DOE@TEST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd!")
            },
            new ApplicationUser
            {
                Id = "6565AAA9-8B95-447A-9540-BEEAB3A8A0F1",
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@test.com",
                NormalizedEmail = "JANE.DOE@TEST.COM",
                EmailConfirmed = true,
                UserName = "Jane.Doe@test.com",
                NormalizedUserName = "JANE.DOE@TEST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            });
    }
}