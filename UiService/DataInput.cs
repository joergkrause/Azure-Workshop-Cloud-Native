using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace UiService
{
  public static class DataInput
  {
    [FunctionName("DataInput")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        [Blob("files/{rand-guid}.txt", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream blob,
        ILogger log)
    {
      log.LogInformation("C# HTTP trigger function processed a request.");

      string name = req.Query["name"];
      var writer = new StreamWriter(blob);
      writer.Write(name);
      writer.Flush();

      log.LogInformation("Write {name} to blob.", name);

      return new OkObjectResult("OK");
    }
  }
}
