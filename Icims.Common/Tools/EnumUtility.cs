using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.Common.Tools
{
  public static class EnumUtility
  {
    public static string GetLiteral(this System.Enum e)
    {
      var attr = e.GetAttributeOnEnum<EnumLiteralAttribute>();

      if (attr != null)
        return attr.Literal;
      else
        return null;
    }
  }
}
