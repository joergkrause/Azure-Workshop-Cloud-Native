using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
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
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "sql/{status}")] HttpRequest req,
        [Sql(commandText: "SELECT * FROM [dbo].[Table] WHERE Status = @Status",
             commandType: System.Data.CommandType.Text,
             parameters: "@Status={status}",
             connectionStringSetting: "SqlServerConnection")] IEnumerable<StorageItem> input,
        ILogger log)
    {
      log.LogInformation("C# HTTP trigger with SQL Output Binding function processed a request.");
      // ?
      return new OkObjectResult(JsonSerializer.Serialize(input));

    }
  }

}
