namespace BookList_v2._0.Models;

public class Company
{
    [Key]
    public Guid Id { get; set; }

    [Display(Name = "Company Name")]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Display(Name = "Street")]
    public string StreetAddress { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    [Display(Name = "Postal Code")]
    public string PostalCode { get; set; }

    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Is Authorized Company?")]
    public bool IsAuthorizedCompany { get; set; }
}