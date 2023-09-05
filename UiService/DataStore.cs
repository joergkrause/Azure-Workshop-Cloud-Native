using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace UiService
{
  public static class DataStore
  {
    [FunctionName("DataStore")]
    public static void Run([BlobTrigger("files/{filename}.{extension}", Connection = "AzureWebJobsStorage")] Stream myBlob,
      string filename,
      string extension,
      // [Blob("files/{filename}.pdf", FileAccess.Read, Connection = "AzureWebJobsStorage")] byte[] content,
      [Queue("%StorageQueueName%", Connection = "AzureWebJobsStorage")] ICollector<StorageItem> queueMessage,
      ILogger log)
    {
      log.LogInformation($"C# Blob trigger function Processed blob\n Name:{filename}.{extension} \n Size: {myBlob.Length} Bytes");

      // .txt .json .pdf
      var blobContent = new byte[myBlob.Length];
      myBlob.Read(blobContent, 0, (int)myBlob.Length);
      var content = System.Text.Encoding.UTF8.GetString(blobContent);

      queueMessage.Add(new StorageItem { 
        Content = content, 
        Name = filename, 
        Created = DateTime.UtcNow, 
        Container = "jk" // Demo !!
      });
    }
  }
}
