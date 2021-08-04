//Christopher Sanderson
//CMS-Window-Systems-Christopher-Sanderson
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
        private QRTableInterface I_QRTable;

        public HomeController(ILogger<HomeController> logger, QRTableInterface qrTableInterface)
        {
            _logger = logger;
            I_QRTable = qrTableInterface;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.barcode = 0;
            //string KVPString = "Null";
            Byte[] byteArray = Array.Empty<byte>();
            indexViewModel.qrKVP = new KeyValuePair<string, byte[]>("Null",byteArray);
            indexViewModel.isKVP = false;
            return View(indexViewModel);
        }

        //private string qrTestString;
        [HttpPost]
        public IActionResult Index(IndexViewModel IndexVM /*int qrText, int qrTextNumberTwo, int qrTextNumberThree*/)
        {
            string qrText = IndexVM.barcode.ToString();//qrText.ToString()+qrTextNumberTwo.ToString() + qrTextNumberThree.ToString();
            //creating string variables to be able to insert them into the url with and also to be able to decode the barcode with ItemKeyID being 3 characters and JobKeyID being 8 characters
            string ItemKeyID;
            string JobKeyID;

            //this checks the length of the barcode finds out the ItemKeyID by finding out how long it is
            if(qrText.Length == 11)
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
            else if (qrText.ToString().Length == 4)
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
                JobKeyID = qrText.ToString().Substring(0,1);
            }
            else
            {
                IndexVM.barcode = 0;
                IndexVM.isKVP = false;
                return View(IndexVM);
            }
            //this variable has been created to store the URL as a string ad also allows the insert of the JobKeyID and the ItemKeyID in their string form
            string qrWebUri = "https://www.mywebsite.com/q?JobKeyID="+ JobKeyID + ",ItemKeyID="+ ItemKeyID;
            //this generates an instace of a  QR code
            QRCodeGenerator qRGenerator = new QRCodeGenerator();
            //this creates an instance that allows the storage of the url to the QR Code and makes it able for the QR code to be interactive and sets the level for the QR code
            QRCodeData qRCodeData = qRGenerator.CreateQrCode(qrWebUri, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap qRCodeImage = qRCode.GetGraphic(20);
            //this sets the Key Value Pair setting of the company, address and the QR code Graphics 
            string CompanyAndAddress = "Castlecary Road 1 CMS Enviro ltd";
            Byte[] byteData = BitmapToBytes(qRCodeImage);

            //this creates an instance of the QRTable which is going store the values of each field the will be used to create a new record of the QRTable's  Table in the Database being used
            QRTable qRTable = new QRTable();
            long JobID = long.Parse(JobKeyID);
            int itemID = int.Parse(ItemKeyID);
            qRTable.JobKeyID = JobID;
            qRTable.ItemKeyID = itemID;
            qRTable.ScanDate = DateTime.Now;
            bool recordCreated  = I_QRTable.CreateRecord(qRTable);
            //this chedcks if the database has added the record to the database and then deicdes if it has been successful which it would then show the QR Code to the user or whether to just return the original view
            if(recordCreated == true)
            {
                IndexVM.qrKVP = new KeyValuePair<string, byte[]>(CompanyAndAddress, byteData);
               /* KeyValuePair<string, Byte[]> qrKVP  = new KeyValuePair<string, byte[]>(CompanyAndAddress, byteData)*/;
                IndexVM.isKVP = true;
                return View(IndexVM);//qrKVP);
            }
            else
            {
                return View();
            }
        }

        //this converts the QR Code Data into a byte array  that can then be used to display the QR code to the user.
        private Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                //img.Save(stream, System.Drawing.Imaging.("Castlecary Road 1 CMS Enviro ltd"));

                return stream.ToArray();
            }
        }
        //[HttpGet]
        //public IActionResult GenerateFile()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult GenerateFile(int qrText)
        //{
        //    QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
        //    QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(qrText.ToString(), QRCodeGenerator.ECCLevel.Q);
        //    string fileGuid = Guid.NewGuid().ToString().Substring(0, 4);

        //    qRCodeData.SaveRawData("wwwroot/qrr/file-" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);

        //    QRCodeData qrCodeData1 = new QRCodeData("wwwroot/qrr/file-" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);
        //    QRCode qrCode = new QRCode(qrCodeData1);
        //    Bitmap qrCodeImage = qrCode.GetGraphic(20);

        //    return View(BitmapToBytes(qrCodeImage));
        //}

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
