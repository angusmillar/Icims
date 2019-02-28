using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.Common.Models.IcimsInterface
{
  public class IcimsResponse : IIcimsResponse
  {
    public string state { get; set; }
    public string error { get; set; }
  }
}
