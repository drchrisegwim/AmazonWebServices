using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AwsS3BucketUpload.Models
{
    public class Document
    {
        //public string Name { get; set; }
        //public string BucketName { get; set; }

        //public string S3DirectoryName { get; set; }

        //public string S3FileName { get; set; }

        //public bool A { get; set; }


        [Required]
        public HttpPostedFileBase File { get; set; }
        public int FileSize { get; set; }

        [Display(Name = "Mime Type")]
        public string MimeType { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public string RelativeUrl { get; set; }

        public int Id { get; set; }
        public string BlobKey { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

    }
}