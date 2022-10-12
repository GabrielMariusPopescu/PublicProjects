namespace CarRentalManagement.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public VehiclesController(
        IUnitOfWork unitOfWork,
        IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    public async Task<IActionResult> GetVehicle()
    {
        var vehicles = await _unitOfWork.Vehicle.GetAll(includes: q => q.Include(x=>x.Brand).Include(x=>x.Model).Include(x=>x.Color));
        return Ok(vehicles);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetVehicle(Guid id)
    {
        var vehicle = await _unitOfWork.Vehicle.Get(it => it.Id == id);
        return vehicle == null ? NotFound() : Ok(vehicle);
    }

    [HttpGet("{id:guid}/details")]
    public async Task<IActionResult> GetVehicleDetails(Guid id)
    {
        var vehicle = await _unitOfWork.Vehicle.Get(it => it.Id == id, q=>q.Include(x=>x.Brand).Include(x=>x.Model).Include(x=>x.Color).Include(x=>x.Rentals));
        return vehicle == null ? NotFound() : Ok(vehicle);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutVehicle(Guid id, Vehicle vehicle)
    {
        if (id != vehicle.Id)
            return BadRequest();

        vehicle.UpsertImage(_webHostEnvironment);
        _unitOfWork.Vehicle.Update(vehicle);

        try
        {
            await _unitOfWork.SaveAsync(HttpContext);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await VehicleExists(id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> PostVehicle(Vehicle vehicle)
    {
        vehicle.UpsertImage(_webHostEnvironment);
        await _unitOfWork.Vehicle.Insert(vehicle);
        await _unitOfWork.SaveAsync(HttpContext);
        return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteVehicle(Guid id)
    {
        if (!await VehicleExists(id))
            return NotFound();

        await _unitOfWork.Vehicle.Delete(id);
        await _unitOfWork.SaveAsync(HttpContext);
        return NoContent();
    }

    private async Task<bool> VehicleExists(Guid id)
    {
        var vehicle = await _unitOfWork.Vehicle.Get(it => it.Id == id);
        return vehicle != null;
    }
}