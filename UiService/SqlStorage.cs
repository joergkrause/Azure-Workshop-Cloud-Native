using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace UiService
{
  public static class SqlStorage
  {
    // Visit https://aka.ms/sqlbindingsoutput to learn how to use this output binding
    [FunctionName("SqlStorage")]
    public static void Run(
        [QueueTrigger("%StorageQueueName%", Connection = "AzureWebJobsStorage")] StorageItem myQueueItem,
        [Sql(commandText: "SELECT [dbo].[Content] ([Id], [Priority], [Description]) FROM dbo.Content WHERE Status = @Status",
                CommandType = System.Data.CommandType.Text,
                Parameters = "@Status={Status}",
                ConnectionStringSetting = "SqlServer")] IEnumerable<StorageItem> input,
        ILogger log)
    {
      log.LogInformation("C# HTTP trigger with SQL Output Binding function processed a request.");
      // ?

    }
  }

}
