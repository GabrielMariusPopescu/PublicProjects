namespace BookList_v2._0.Areas.Admin.Controllers;

[Area("Admin")]
public class UserController : Controller
{
    public UserController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var users = dbContext.ApplicationUsers.Include(user => user.Company).ToList();
        var userRoles = dbContext.UserRoles.ToList();
        var roles = dbContext.Roles.ToList();
        foreach (var user in users)
        {
            var roleId = userRoles.FirstOrDefault(userRole => userRole.UserId == user.Id)?.RoleId;
            user.Role = roles.FirstOrDefault(role => role.Id == roleId)?.Name;
            user.Company ??= new Company
            {
                Name = ""
            };
        }
        return View(users);
    }

    //

    private readonly ApplicationDbContext dbContext;
}