namespace BookList_v2._0.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    public CategoryController(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

    public IActionResult Index()
    {
        var categories = unitOfWork.CategoryRepository.GetAll();
        return View(categories);
    }

    public IActionResult Upsert(Guid? id)
    {
        var category = new Category();
        if (id == null)
            return View(category);

        var guid = id.GetValueOrDefault();
        category = unitOfWork.CategoryRepository.Get(guid);

        if (category == null)
            return NotFound();

        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Category category)
    {
        if (!ModelState.IsValid)
            return View(category);

        if (category.Id == Guid.Empty)
            unitOfWork.CategoryRepository.Add(category);
        else
            unitOfWork.CategoryRepository.Update(category);

        unitOfWork.Save();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(Guid id)
    {
        var categoryToDelete = unitOfWork.CategoryRepository.Get(id);
        if (categoryToDelete == null)
            return RedirectToAction(nameof(Upsert));

        unitOfWork.CategoryRepository.Remove(categoryToDelete);
        unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }

    //

    private readonly IUnitOfWork unitOfWork;
}