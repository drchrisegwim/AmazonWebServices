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


        [ HttpPost]
        public ActionResult Create(Document document)
        {
            if (ModelState.IsValid)
            {
                if (document.File != null)
                {
                    var file = document.File;




                    Stream st = file.InputStream;

                    string name = file.FileName;
                    string myBucketName = "vgg-aws-tst-bucket"; //your s3 bucket name goes here  
                    string s3DirectoryName = "EdutechApplyV3";
                    string s3FileName = file.FileName;
                    AmazonUploader myUploader = new AmazonUploader();
                    var uploadStatus = myUploader.SendMyFileToS3(st, myBucketName, s3DirectoryName, s3FileName);
                    if (uploadStatus == true)
                    {
                        Content("successfully uploaded");
                    }
                    else
                        Content("Error");

                    return RedirectToAction("Index");
                }
                //ErrorNotification(Domain.Messages.Document.Admin.DocumentInvalid);

            }

            return View("Index",document);
        }
    }
}