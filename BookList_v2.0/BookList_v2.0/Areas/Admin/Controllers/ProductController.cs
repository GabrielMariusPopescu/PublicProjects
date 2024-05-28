namespace BookList_v2._0.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        this.unitOfWork = unitOfWork;
        this.webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        var products = unitOfWork.ProductRepository.GetAll(includeProperties: "Category,Cover");
        return View(products);
    }

    public IActionResult Upsert(Guid? id)
    {
        var viewModel = new ProductViewModel
        {
            Product = new Product(),
            Categories = unitOfWork.CategoryRepository.GetAll().Select(category => new SelectListItem
            {
                Text = category.Name,
                Value = category.Id.ToString()
            }),
            Covers = unitOfWork.CoverRepository.GetAll().Select(cover => new SelectListItem
            {
                Text = cover.Name,
                Value = cover.Id.ToString()
            })
        };

        if (id == null)
            return View(viewModel);

        var guid = id.GetValueOrDefault();

        viewModel.Product = unitOfWork.ProductRepository.Get(guid);
        if (viewModel.Product == null)
            return NotFound();

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(ProductViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Categories = unitOfWork.CategoryRepository.GetAll().Select(category => new SelectListItem
            {
                Text = category.Name,
                Value = category.Id.ToString()
            });
            viewModel.Covers = unitOfWork.CoverRepository.GetAll().Select(cover => new SelectListItem
            {
                Text = cover.Name,
                Value = cover.Id.ToString()
            });
            if (viewModel.Product.Id != Guid.Empty)
            {
                viewModel.Product = unitOfWork.ProductRepository.Get(viewModel.Product.Id);
            }
            return View(viewModel);
        }

        var webRootPath = webHostEnvironment.WebRootPath;
        var images = HttpContext.Request.Form.Files;
        if (images.Count > 0)
        {
            var fileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images\products");
            var extension = Path.GetExtension(images[0].FileName);
            if (viewModel.Product.ImageUrl != null)
            {
                // this is an edit and we need to remove old image
                var imagePath = Path.Combine(webRootPath, viewModel.Product.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            using (var stream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                images[0].CopyTo(stream);
            }

            viewModel.Product.ImageUrl = $@"\images\products\{fileName}{extension}";
        }
        else
        {
            // upload when they do not change the image
            if (viewModel.Product.Id != Guid.Empty)
            {
                var dbProduct = unitOfWork.ProductRepository.Get(viewModel.Product.Id);
                viewModel.Product.ImageUrl = dbProduct.ImageUrl;
            }
        }

        if (viewModel.Product.Id == Guid.Empty)
            unitOfWork.ProductRepository.Add(viewModel.Product);
        else
            unitOfWork.ProductRepository.Update(viewModel.Product);

        unitOfWork.Save();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(Guid id)
    {
        var productToDelete = unitOfWork.ProductRepository.Get(id);
        if (productToDelete == null)
            return RedirectToAction(nameof(Upsert));

        var webRootPath = webHostEnvironment.WebRootPath;
        var imagePath = Path.Combine(webRootPath, productToDelete.ImageUrl.TrimStart('\\'));
        if (System.IO.File.Exists(imagePath))
        {
            System.IO.File.Delete(imagePath);
        }
        unitOfWork.ProductRepository.Remove(productToDelete);
        unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }

    //

    private readonly IUnitOfWork unitOfWork;
    private readonly IWebHostEnvironment webHostEnvironment;
}