using IronBarCode;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using VCardGenerate.Models;
using ZXing.QrCode.Internal;
using IronBarCode;

namespace VCardGenerate.Controllers;

public class VCardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Index(VCard model)
    {
        //// You may add styling with color, logo images or branding:
        //QRCodeLogo qrCodeLogo = new QRCodeLogo("visual-studio-logo.png");
        //GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo("https://ironsoftware.com/", qrCodeLogo);
        //myQRCodeWithLogo.ChangeBarCodeColor(System.Drawing.Color.DarkGreen);

        //// Save as image
        //myQRCodeWithLogo.SaveAsImage("sekil.jpg");


        //using (MemoryStream ms = new MemoryStream())
        //{
        //    QRCodeGenerator oQRCodeGenerator = new QRCodeGenerator();
        //    QRCodeData oQRCodeData = oQRCodeGenerator.CreateQrCode(model.VCardToText(), QRCodeGenerator.ECCLevel.Q);
        //    QRCode oQRCode = new QRCode(oQRCodeData);
        //    using (Bitmap oBitmap = oQRCode.GetGraphic(20))
        //    {
        //        oBitmap.Save(ms, ImageFormat.Png);
        //        ViewBag.QRCode = "data:image/png;base64, " + Convert.ToBase64String(ms.ToArray());
        //    }

        //}
        return View();
    }

    public IActionResult Create() => View();
    
    
    [HttpPost]
    public IActionResult Create(VCard model)
    {
        if (ModelState.IsValid)
        {
            var vCard = new VCard
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PhoneType = model.PhoneType,
                City = model.City,
                Country = model.Country
            };

            return RedirectToAction("Index");
        }

        return View(model);
    }
}
