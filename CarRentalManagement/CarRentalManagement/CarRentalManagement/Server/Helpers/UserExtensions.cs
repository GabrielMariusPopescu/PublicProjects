namespace CarRentalManagement.Server.Helpers;

public static class UserExtensions
{
    public static Guid GetUserId(this IPrincipal principal)
    {
        var claimsIdentity = (ClaimsIdentity)principal.Identity;
        var claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
        return claim != null ? new Guid(claim.Value) : Guid.Empty;
    }
}