using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGram.Models.Utility
{
    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }

        public CloudBlobClient CloudBlobClient { get; set; }

        public Blob(IConfiguration configuation)
        {
            CloudStorageAccount = CloudStorageAccount.Parse(configuation["BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            return cbc;
        }

        public async Task<CloudBlob> GetBlob(string imageURL, string containerName)
        {
            CloudBlobContainer container = await GetContainer(containerName); //if do know container
            //var container = CloudBlobClient.GetContaerReference(containerName); //if don't know container
            CloudBlob blob = container.GetBlobReference(imageURL);
            return blob;
        }

        public async void AddBlob(string fileName, CloudBlobContainer cbContainer, string filePath)
        {
            var blobFile = cbContainer.GetBlockBlobReference(fileName);
            await blobFile.UploadFromFileAsync(filePath);
        }

    }
}
