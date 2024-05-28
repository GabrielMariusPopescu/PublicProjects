namespace BookList_v2._0.Areas.Admin.Controllers;

[Area("Admin")]
public class CoverController : Controller
{
    public CoverController(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

    public IActionResult Index()
    {
        var covers = unitOfWork.CoverRepository.GetAll();
        return View(covers);
    }

    public IActionResult Upsert(Guid? id)
    {
        var cover = new Cover();
        if (id == null)
            return View(cover);

        var guid = id.GetValueOrDefault();
        cover = unitOfWork.CoverRepository.Get(guid);

        if (cover == null)
            return NotFound();

        return View(cover);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Cover cover)
    {
        if (!ModelState.IsValid)
            return View(cover);

        if (cover.Id == Guid.Empty)
            unitOfWork.CoverRepository.Add(cover);
        else
            unitOfWork.CoverRepository.Update(cover);

        unitOfWork.Save();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(Guid id)
    {
        var coverToDelete = unitOfWork.CoverRepository.Get(id);
        if (coverToDelete == null)
            return RedirectToAction(nameof(Upsert));

        unitOfWork.CoverRepository.Remove(coverToDelete);
        unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }

    //

    private readonly IUnitOfWork unitOfWork;

}