// Decompiled with JetBrains decompiler
// Type: Uno.Arguments
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Uno
{
  public class Arguments
  {
    private StringDictionary Parameters;

    public string this[string Param]
    {
      get
      {
        return this.Parameters[Param];
      }
    }

    public Arguments(string[] Args)
    {
      this.Parameters = new StringDictionary();
      Regex regex1 = new Regex("^-{1,2}|^/|=|:", RegexOptions.IgnoreCase | RegexOptions.Compiled);
      Regex regex2 = new Regex("^['\"]?(.*?)['\"]?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
      string key1 = (string) null;
      foreach (string input in Args)
      {
        string[] strArray = regex1.Split(input, 3);
        switch (strArray.Length)
        {
          case 1:
            if (key1 != null)
            {
              if (!this.Parameters.ContainsKey(key1))
              {
                strArray[0] = regex2.Replace(strArray[0], "$1");
                this.Parameters.Add(key1, strArray[0]);
              }
              key1 = (string) null;
              break;
            }
            break;
          case 2:
            if (key1 != null && !this.Parameters.ContainsKey(key1))
              this.Parameters.Add(key1, "true");
            key1 = strArray[1];
            break;
          case 3:
            if (key1 != null && !this.Parameters.ContainsKey(key1))
              this.Parameters.Add(key1, "true");
            string key2 = strArray[1];
            if (!this.Parameters.ContainsKey(key2))
            {
              strArray[2] = regex2.Replace(strArray[2], "$1");
              this.Parameters.Add(key2, strArray[2]);
            }
            key1 = (string) null;
            break;
        }
      }
      if (key1 == null || this.Parameters.ContainsKey(key1))
        return;
      this.Parameters.Add(key1, "true");
    }
  }
}
