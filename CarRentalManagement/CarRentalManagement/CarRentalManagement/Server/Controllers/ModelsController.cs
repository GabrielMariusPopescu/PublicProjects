namespace CarRentalManagement.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ModelsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ModelsController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetModels()
    {
        var models = await _unitOfWork.Model.GetAll();
        return Ok(models);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetModel(Guid id)
    {
        var model = await _unitOfWork.Model.Get(it => it.Id == id);
        return model == null ? NotFound() : Ok(model);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutModel(Guid id, Model model)
    {
        if (id != model.Id)
            return BadRequest();

        _unitOfWork.Model.Update(model);

        try
        {
            await _unitOfWork.SaveAsync(HttpContext);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await ModelExists(id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> PostModel(Model model)
    {
        await _unitOfWork.Model.Insert(model);
        await _unitOfWork.SaveAsync(HttpContext);
        return CreatedAtAction("GetModel", new { id = model.Id }, model);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteModel(Guid id)
    {
        if (!await ModelExists(id))
            return NotFound();

        await _unitOfWork.Model.Delete(id);
        await _unitOfWork.SaveAsync(HttpContext);
        return NoContent();
    }

    private async Task<bool> ModelExists(Guid id)
    {
        var model = await _unitOfWork.Model.Get(it => it.Id == id);
        return model != null;
    }
}