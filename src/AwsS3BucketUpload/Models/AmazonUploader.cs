using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Amazon;
using Amazon.Internal;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace AwsS3BucketUpload.Models
{
    public class AmazonUploader
    {
        public bool SendMyFileToS3(Stream localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3)
        {
            
            AmazonS3Client client = new AmazonS3Client( RegionEndpoint.EUWest1);
            TransferUtility utility = new TransferUtility(client);
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

            if (string.IsNullOrEmpty(subDirectoryInBucket))
            {
                request.BucketName = bucketName; //no subdirectory just bucket name  
            }
            else
            {   // subdirectory and bucket name  
                request.BucketName = bucketName ;
            }
            request.Key = subDirectoryInBucket + @"/" + fileNameInS3; //file name up in S3  
            request.InputStream = localFilePath;
            utility.Upload(request); //commensing the transfer  

            return true; //indicate that the file was sent  
        }


    }
}