using CMS_Window_Systems_Christopher_Sanderson.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using QRCoder;
using System.Drawing.Printing;

namespace CMS_Window_Systems_Christopher_Sanderson.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int qrText)
        {
            string ItemKeyID;
            string JobKeyID;
            //int qrTextLength = qrText.ToString().Length;
            if(qrText.ToString().Length == 11)
            {
                 ItemKeyID = qrText.ToString().Substring(8);
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                JobKeyID = qrText.ToString().Substring(0,8);
            }
            else if (qrText.ToString().Length == 10)
            {
                 ItemKeyID = qrText.ToString().Substring(7);
                if(ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                JobKeyID = qrText.ToString().Substring(0,7);
            }
            else if (qrText.ToString().Length == 9)
            {
                ItemKeyID = qrText.ToString().Substring(6);
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                JobKeyID = qrText.ToString().Substring(0,6);
            }
            else if (qrText.ToString().Length == 8)
            {
                ItemKeyID = qrText.ToString().Substring(5);
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                JobKeyID = qrText.ToString().Substring(0,5);
            }
            else if (qrText.ToString().Length == 7)
            {
                ItemKeyID = qrText.ToString().Substring(4);
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                JobKeyID = qrText.ToString().Substring(0,4);
            }
            else if (qrText.ToString().Length == 6)
            {
                ItemKeyID = qrText.ToString().Substring(3);
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                JobKeyID = qrText.ToString().Substring(0,3);
            }
            else if (qrText.ToString().Length == 5)
            {
                ItemKeyID = qrText.ToString().Substring(2);
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                JobKeyID = qrText.ToString().Substring(0,2);
            }
            else
            {
                ItemKeyID = qrText.ToString().Substring(1);
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                if (ItemKeyID.StartsWith('0'))
                {
                    ItemKeyID = ItemKeyID.Substring(1);
                }
                JobKeyID = qrText.ToString().Substring(0);
            }
            string qrWebUri = "https://www.mywebsite.com/q?JobKeyID="+ JobKeyID + ",ItemKeyID="+ ItemKeyID;
            QRCodeGenerator qRGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRGenerator.CreateQrCode(qrWebUri, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap qRCodeImage = qRCode.GetGraphic(20);
            string CompanyAndAddress = "Castlecary Road 1 CMS Enviro ltd";
            Byte[] byteData = BitmapToBytes(qRCodeImage);

            KeyValuePair<string, Byte[]> qrKVP  = new KeyValuePair<string, byte[]>(CompanyAndAddress, byteData);

            //qrKVP.Key = CompanyAndAddress;
            //qrKVP.Value = byteData;
            return View(qrKVP);

        //return View(BitmapToBytes(qRCodeImage));
        }
                StreamReader streamToPrint;
        private Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                //img.Save(stream, System.Drawing.Imaging.("Castlecary Road 1 CMS Enviro ltd"));
                try
                {
                    //Print The file
                    streamToPrint = new StreamReader(String.Format("data:image/png;base64,{0}", Convert.ToBase64String(stream.ToArray())));
                    try
                    {
                        printFont = new Font("Arial", 10);
                        PrintDocument pd = new PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                        pd.Print();
                    }
                    finally
                    {
                        streamToPrint.Close();
                    }
                }
                catch (Exception ex)
                {

                }
                return stream.ToArray();
            }
        }
        Font printFont;

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float ypos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            String line = null;

            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            while(count < linesPerPage && ((line=streamToPrint.ReadLine()) != null))
            {
                ypos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, ypos, new StringFormat());
                count++;
            }
            if (line != null)
            {
                ev.HasMorePages = true;
            }
            else
            {
                ev.HasMorePages = false;
            }
        }
        [HttpGet]
        public IActionResult GenerateFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateFile(int qrText)
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(qrText.ToString(), QRCodeGenerator.ECCLevel.Q);
            string fileGuid = Guid.NewGuid().ToString().Substring(0, 4);

            qRCodeData.SaveRawData("wwwroot/qrr/file-" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);

            QRCodeData qrCodeData1 = new QRCodeData("wwwroot/qrr/file-" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);
            QRCode qrCode = new QRCode(qrCodeData1);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            return View(BitmapToBytes(qrCodeImage));
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
