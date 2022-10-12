namespace CarRentalManagement.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomersController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _unitOfWork.Customer.GetAll();
        return Ok(customers);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCustomer(Guid id)
    {
        var customer = await _unitOfWork.Customer.Get(it => it.Id == id);
        return customer == null ? NotFound() : Ok(customer);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutCustomer(Guid id, Customer customer)
    {
        if (id != customer.Id)
            return BadRequest();

        _unitOfWork.Customer.Update(customer);

        try
        {
            await _unitOfWork.SaveAsync(HttpContext);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CustomerExists(id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> PostCustomer(Customer customer)
    {
        await _unitOfWork.Customer.Insert(customer);
        await _unitOfWork.SaveAsync(HttpContext);
        return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        if (!await CustomerExists(id))
            return NotFound();

        await _unitOfWork.Customer.Delete(id);
        await _unitOfWork.SaveAsync(HttpContext);
        return NoContent();
    }

    private async Task<bool> CustomerExists(Guid id)
    {
        var customer = await _unitOfWork.Customer.Get(it => it.Id == id);
        return customer != null;
    }
}