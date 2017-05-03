using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
namespace Appclass
{
   public class BlobM
    {

        public static BlobM Instance
        {
            get;
        } = new BlobM();

        public BlobM()
        {

            _lowrescontainer = _blobclient.GetContainerReference("fulllas");
            _fullrescontainer = _blobclient.GetContainerReference("lowers");

        }


        CloudBlobClient _blobclient = CloudStorageAccount.Parse(connectionString).CreateCloudBlobClient();


        const string connectionString = "DefaultEndpointsProtocol=https;AccountName=xamublobdemo;AccountKey=ZdpTzGriWN28xKwK7wj8zWdcFxCZAYvCAVQNGgYLDw7ICLcjD8jc9I7VGtomvY3u3L7nirxXGaop52Os2OviRQ==;";



        CloudBlobContainer _lowrescontainer;
        CloudBlobContainer _fullrescontainer;


        public async Task<List<Uri>> getallblobasync()
        {
            var centoken = new BlobContinuationToken();
            var alosblobs = await _fullrescontainer.ListBlobsSegmentedAsync(centoken).ConfigureAwait(false);
            var uris = alosblobs.Results.Select(b => b.Uri).ToList();

            return uris;

        }

        public async Task uploadfileasync(string localpath)
        {
            var uniqueblobname = Guid.NewGuid().ToString();

            uniqueblobname += Path.GetExtension(localpath);
            var blobref = _fullrescontainer.GetBlockBlobReference(uniqueblobname);

            //  await blobref.UploadFromFileAsync(localpath).ConfigurAwait(false);




        }


    }
}

    

