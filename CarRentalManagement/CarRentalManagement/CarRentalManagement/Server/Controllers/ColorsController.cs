namespace CarRentalManagement.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ColorsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ColorsController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetColors()
    {
        var colors = await _unitOfWork.Color.GetAll();
        return Ok(colors);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetColor(Guid id)
    {
        var color = await _unitOfWork.Color.Get(it => it.Id == id);
        return color == null ? NotFound() : Ok(color);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutColor(Guid id, Color color)
    {
        if (id != color.Id)
            return BadRequest();

        _unitOfWork.Color.Update(color);

        try
        {
            await _unitOfWork.SaveAsync(HttpContext);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await ColorExists(id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> PostColor(Color color)
    {
        await _unitOfWork.Color.Insert(color);
        await _unitOfWork.SaveAsync(HttpContext);
        return CreatedAtAction("GetColor", new { id = color.Id }, color);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteColor(Guid id)
    {
        if (!await ColorExists(id))
            return NotFound();

        await _unitOfWork.Color.Delete(id);
        await _unitOfWork.SaveAsync(HttpContext);
        return NoContent();
    }

    private async Task<bool> ColorExists(Guid id)
    {
        var color = await _unitOfWork.Color.Get(it => it.Id == id);
        return color != null;
    }
}