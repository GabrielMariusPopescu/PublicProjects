namespace CarRentalManagement.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class RentalsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public RentalsController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetRental()
    {
        var rentals = await _unitOfWork.Rental.GetAll(includes: q => q.Include(x => x.Vehicle).Include(x => x.Customer));
        return Ok(rentals);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRental(Guid id)
    {
        var rental = await _unitOfWork.Rental.Get(it => it.Id == id);
        return rental == null ? NotFound() : Ok(rental);
    }

    [HttpGet("{id:guid}/details")]
    public async Task<IActionResult> GetRentalDetails(Guid id)
    {
        var rental = await _unitOfWork.Rental.Get(it => it.Id == id, includes: q => q.Include(x => x.Vehicle).Include(x => x.Customer));
        return rental == null ? NotFound() : Ok(rental);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutRental(Guid id, Rental rental)
    {
        if (id != rental.Id)
            return BadRequest();

        _unitOfWork.Rental.Update(rental);

        try
        {
            await _unitOfWork.SaveAsync(HttpContext);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await RentalExists(id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> PostRental(Rental rental)
    {
        await _unitOfWork.Rental.Insert(rental);
        await _unitOfWork.SaveAsync(HttpContext);
        return CreatedAtAction("GetRental", new { id = rental.Id }, rental);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRental(Guid id)
    {
        if (!await RentalExists(id))
            return NotFound();

        await _unitOfWork.Rental.Delete(id);
        await _unitOfWork.SaveAsync(HttpContext);
        return NoContent();
    }

    private async Task<bool> RentalExists(Guid id)
    {
        var rental = await _unitOfWork.Rental.Get(it => it.Id == id);
        return rental != null;
    }
}