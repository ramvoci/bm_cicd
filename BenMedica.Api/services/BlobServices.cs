using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace BenMedica.Api {
    public class BlobServices : IBlobService {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobServices(BlobServiceClient blobServiceClient) {
            _blobServiceClient = blobServiceClient;
        }
        public Task DeleteBlobAsync(string blobName) {
            throw new NotImplementedException();
        }

        // public Task<BlobInfo> IBlobService.GetBlobAsync(string name) {
        //    var containerClient = _blobServiceClient.GetBlobContainerClient("ci-benmedica-dev");
        //    var blobClient = containerClient.GetBlobClient(name);

        //    return await blobClient.DownloadAsync();
        //}

        /// <summary>
        /// Get blob
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<BlobDownloadInfo> GetBlobAsync(string name) {
            var containerClient =  _blobServiceClient.GetBlobContainerClient("ci-benmedica-dev");
            var blobClient= containerClient.GetBlobClient(name);
            
               return await blobClient.DownloadAsync();
                //using (var streamReader = new StreamReader(response.Value.Content)) {
                //    while (!streamReader.EndOfStream) {
                //        var line = await streamReader.ReadLineAsync();
                //        //Console.WriteLine(line);
                //    }
                //}
            
        }

        public Task<IEnumerable<string>> ListBlobsAsync() {
            throw new NotImplementedException();
        }

        public Task UploadContentBlobAsync(string content, string fileName) {
            throw new NotImplementedException();
        }

        public Task UploadFileBlobAsync(string filePath, string fileName) {
            throw new NotImplementedException();
        }

        //async Task<BlobDownloadInfo> IBlobService.GetBlobAsync(string name) {
        //    var containerClient = _blobServiceClient.GetBlobContainerClient("ci-benmedica-dev");
        //    var blobClient = containerClient.GetBlobClient(name);

        //    return await blobClient.DownloadAsync();
        //}

        
    }
}
