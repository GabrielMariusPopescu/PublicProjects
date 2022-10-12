namespace CarRentalManagement.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public BrandsController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetBrands()
    {
        var brands = await _unitOfWork.Brand.GetAll();
        return Ok(brands);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBrand(Guid id)
    {
        var brand = await _unitOfWork.Brand.Get(it => it.Id == id);
        return brand == null ? NotFound() : Ok(brand);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutBrand(Guid id, Brand brand)
    {
        if (id != brand.Id)
            return BadRequest();

        _unitOfWork.Brand.Update(brand);

        try
        {
            await _unitOfWork.SaveAsync(HttpContext);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await BrandExists(id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> PostBrand(Brand brand)
    {
        await _unitOfWork.Brand.Insert(brand);
        await _unitOfWork.SaveAsync(HttpContext);
        return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBrand(Guid id)
    {
        if (!await BrandExists(id))
            return NotFound();

        await _unitOfWork.Brand.Delete(id);
        await _unitOfWork.SaveAsync(HttpContext);
        return NoContent();
    }

    private async Task<bool> BrandExists(Guid id)
    {
        var brand = await _unitOfWork.Brand.Get(it => it.Id == id);
        return brand != null;
    }
}