using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AwsS3BucketUpload.Models;

namespace AwsS3BucketUpload.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Documents
        public ActionResult Index()
        {
            return View();
        }


        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Create(Document document)
        {
            if (ModelState.IsValid)
            {
                if (document.File != null)
                {
                    var file = document.File;




                    Stream st = file.InputStream;

                    string name = file.FileName;
                    string myBucketName = "test73"; //your s3 bucket name goes here  
                    string s3DirectoryName = "";
                    string s3FileName = @name;
                    bool a;
                    AmazonUploader myUploader = new AmazonUploader();
                    a = myUploader.sendMyFileToS3(st, myBucketName, s3DirectoryName, s3FileName);
                    if (a == true)
                    {
                        Response.Write("successfully uploaded");

                    }
                    else
                        Response.Write("Error");





                    // await _documentService.SaveDocument(model.ToEntity(), file.InputStream, file.FileName, file.ContentType, file.ContentLength);

                    // SuccessNotification(Domain.Messages.Document.Admin.DocumentCreated);

                    return RedirectToAction("Index");
                }
                //ErrorNotification(Domain.Messages.Document.Admin.DocumentInvalid);

            }

            return View("Index",document);
        }
    }
}