using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiService
{
  public class StorageItem
  {
    public string Content { get; set; }

    public string Name { get; set; }

    public DateTime Created { get; set; }

    public int Status { get; set; }

    public string Container { get; set; }
  }
}
