namespace BookList_v2._0.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string Name { get; set; }

    public string StreetAddress { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string PostalCode { get; set; }

    public Guid? CompanyId { get; set; }

    [ForeignKey("CompanyId")]
    public Company Company { get; set; }

    [NotMapped]
    public string Role { get; set; }
}