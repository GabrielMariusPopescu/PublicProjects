using IronBarCode;
using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Web.Models;
using System.Diagnostics;
using System.Drawing;

namespace QRCodeGenerator.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IWebHostEnvironment _webHostEnvironment;

		public HomeController(IWebHostEnvironment webHostEnvironment) => _webHostEnvironment = webHostEnvironment;

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult CreateQRCode()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateQRCode(GenerateQRCodeModel generateQRCode)
		{
			var barcode = QRCodeWriter.CreateQrCode(generateQRCode.QRCodeText, 200);
			barcode.AddBarcodeValueTextBelowBarcode();

			barcode.SetMargins(10);
			barcode.ChangeBarCodeColor(Color.BlueViolet);
			var path = Path.Combine(_webHostEnvironment.WebRootPath, "GeneratedQRCode");

			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "GenerateQRCode/qrcode.png");
			barcode.SaveAsPng(filePath);

			var fileName = Path.GetFileName(filePath);
			var imageUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}" + "/GeneratedQRCode/" + fileName;
			ViewBag.QrCodeUri = imageUrl;
			ViewBag.QrName = generateQRCode.QRCodeText;


			return RedirectToAction("CreateQRCode");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}