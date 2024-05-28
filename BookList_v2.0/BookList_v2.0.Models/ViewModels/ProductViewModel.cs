namespace BookList_v2._0.Models.ViewModels;

public class ProductViewModel
{
    public Product Product { get; set; }

    public IEnumerable<SelectListItem> Categories { get; set; }

    public IEnumerable<SelectListItem> Covers { get; set; }
}