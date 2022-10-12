namespace CarRentalManagement.Server.Helpers;

public static class VehicleExtensions
{
    public static void UpsertImage(this Vehicle vehicle, IWebHostEnvironment env)
    {
        if (vehicle.Image == null)
            return;

        var path = $@"{env.WebRootPath}\uploads\{vehicle.ImageName}";
        var fileStream = System.IO.File.Create(path);
        fileStream.Write(vehicle.Image, 0, vehicle.Image.Length);
        fileStream.Close();
        vehicle.ImageName = $"/uploads/{vehicle.ImageName}";
    }
}