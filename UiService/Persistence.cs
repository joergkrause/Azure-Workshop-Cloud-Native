using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace UiService
{
  public static class Persistence
  {
    [FunctionName("Persistence")]
    public static void Run(
      [QueueTrigger("%StorageQueueName%", Connection = "AzureWebJobsStorage")] StorageItem myQueueItem,
      [CosmosDB("storage", "{Container}", Connection = "CosmosDBConnection")] out dynamic document,
      ILogger log)
    {
      log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
      document = myQueueItem;
    }
  }
}
