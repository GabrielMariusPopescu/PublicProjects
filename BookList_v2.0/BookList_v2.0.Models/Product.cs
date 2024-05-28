namespace BookList_v2._0.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }

    [Display(Name = "Name")]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public string Isbn { get; set; }

    [Required]
    public string Author { get; set; }

    [Display(Name = "List Price")]
    [Required]
    [Range(1, 100000)]
    public double ListPrice { get; set; }

    [Display(Name = "Price")]
    [Required]
    [Range(1, 100000)]
    public double Price { get; set; }

    [Display(Name = "Price for 50")]
    [Required]
    [Range(1, 100000)]
    public double PriceFor50 { get; set; }

    [Display(Name = "Price for 100")]
    [Required]
    [Range(1, 100000)]
    public double PriceFor100 { get; set; }

    [Display(Name = "Image")]
    public string ImageUrl { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    [Required]
    public Guid CoverId { get; set; }

    [ForeignKey("CoverId")]
    public Cover Cover { get; set; }
}