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

            return RedirectToAction("DisplayQr", vCard);
        }

        return View(model);
    }

    public IActionResult DisplayQr(VCard model)
    { 
        QRCodeLogo qrCodeLogo = new QRCodeLogo();
        GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo(model.VCardToText(), qrCodeLogo);

        string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        string imagesPath = Path.Combine(wwwRootPath, "assets", "images");

        if (!Directory.Exists(imagesPath))
        {
            Directory.CreateDirectory(imagesPath);
        }

        string fileName = $"{model.PhoneNumber}.jpg";
        string filePath = Path.Combine(imagesPath, fileName);

        // Save the image
        myQRCodeWithLogo.SaveAsImage(filePath);

        model.QrUrl = $"/assets/images/{fileName}";

        return View(model);
    }

}
