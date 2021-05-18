using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace BenMedica.Api {
   public interface IBlobService {
        public Task<BlobDownloadInfo> GetBlobAsync(string name);

        public Task<IEnumerable<string>> ListBlobsAsync();

        public Task UploadFileBlobAsync(string filePath, string fileName);

        public Task UploadContentBlobAsync(string content, string fileName);

        public Task DeleteBlobAsync(string blobName);
    }
}
