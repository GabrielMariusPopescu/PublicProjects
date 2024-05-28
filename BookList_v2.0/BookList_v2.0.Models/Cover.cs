namespace BookList_v2._0.Models;

public class Cover
{
    [Key]
    public Guid Id { get; set; }

    [Display(Name = "Cover Name")]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}