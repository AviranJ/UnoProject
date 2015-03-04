// Decompiled with JetBrains decompiler
// Type: Uno.Program
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System;
using System.Windows.Forms;

namespace Uno
{
  internal static class Program
  {
    [STAThread]
    private static void Main(string[] Args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new frmUno(Args));
    }
  }
}
