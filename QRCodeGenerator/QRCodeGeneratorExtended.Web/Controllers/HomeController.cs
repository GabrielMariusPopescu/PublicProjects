using Microsoft.AspNetCore.Mvc;
using QRCodeGeneratorExtended.Web.Models;
using QRCoder;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace QRCodeGeneratorExtended.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            QRCodeModel model = new QRCodeModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(QRCodeModel model)
        {
            PayloadGenerator.Payload payload = null;
            switch (model.QRCodeType)
            {
                case 1: // website url
                    payload = new PayloadGenerator.Url(model.WebsiteURL);
                    break;
                case 2: // bookmark url
                    payload = new PayloadGenerator.Bookmark(model.BookmarkURL, model.BookmarkURL);
                    break;
                case 3: // compose sms
                    payload = new PayloadGenerator.SMS(model.SMSPhoneNumber, model.SMSBody);
                    break;
                case 4: // compose whatsapp message
                    payload = new PayloadGenerator.WhatsAppMessage(model.WhatsAppNumber, model.WhatsAppMessage);
                    break;
                case 5: //compose email
                    payload = new PayloadGenerator.Mail(model.ReceiverEmailAddress, model.EmailSubject, model.EmailMessage);
                    break;
                case 6: // wifi qr code
                    payload = new PayloadGenerator.WiFi(model.WIFIName, model.WIFIPassword, PayloadGenerator.WiFi.Authentication.WPA);
                    break;
            }
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(20);
            // use this when you want to show your logo in middle of QR Code and change color of qr code
            //Bitmap logoImage = new Bitmap(@"wwwroot/img/Virat-Kohli.jpg");
            //var qrCodeAsBitmap = qrCode.GetGraphic(20, Color.Black, Color.Red, logoImage);
            string base64String = Convert.ToBase64String(BitmapToByteArray(qrCodeAsBitmap));
            model.QRImageURL = "data:image/png;base64," + base64String;
            return View("Index", model);
        }
        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}