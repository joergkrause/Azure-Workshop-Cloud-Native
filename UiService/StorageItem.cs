using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UiService
{
  public class StorageItem
  {
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Content { get; set; }

    public string Name { get; set; }

    public DateTime Created { get; set; }

    public string Status { get; set; } = "Default";

    public string Container { get; set; }
  }
}
