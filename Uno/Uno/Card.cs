// Decompiled with JetBrains decompiler
// Type: Uno.Card
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Uno
{
  public class Card
  {
    public UnoCards number;
    public UnoColours color;
    public int imageListOffset;
    public Image cardImage;

    public Card(UnoCards num, int off, UnoColours col)
    {
      Logger.FuncInit("Card.Card");
      Logger.Write(3, "Card details - " + (object) num + " " + (string) (object) off + " " + (string) (object) col);
      this.number = num;
      this.imageListOffset = off;
      this.color = col;
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      string name = "Uno.Images." + GameData.cardImageList[off];
      Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
      if (manifestResourceStream == null)
      {
        int num1 = (int) MessageBox.Show("Unable to find resource " + name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Application.Exit();
      }
      else
      {
        Image image = (Image) (Image.FromStream(manifestResourceStream) as Bitmap);
        if (image == null)
        {
          Logger.Write(3, "Error - Cannot convert resource " + name + " to image");
          int num1 = (int) MessageBox.Show("Cannot convert resource " + name + " to image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          Application.Exit();
        }
        else
          this.cardImage = image;
      }
      Logger.FuncExit("Card.Card");
    }

    public override string ToString()
    {
      return (string) (object) this.number + (object) " of " + this.color.ToString();
    }
  }
}
