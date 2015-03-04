// Decompiled with JetBrains decompiler
// Type: Uno.Tools
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Uno
{
  internal class Tools
  {
    private static Timer timer = new Timer();
    private static long start = 0L;

    [DllImport("user32.dll")]
    private static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

    public static int GetPoint(Card card)
    {
      if (card.number > UnoCards.Zero && card.number <= UnoCards.Nine)
        return (int) card.number;
      if (card.number > UnoCards.Nine && card.number < UnoCards.WildCard)
        return 20;
      return card.number >= UnoCards.WildCard && card.number <= UnoCards.DrawFour ? 50 : 0;
    }

    public static Size BestFitSize(Size origSize, Size newSize)
    {
      int width = origSize.Width;
      int height = origSize.Height;
      if (width <= newSize.Width && height <= newSize.Height)
        return origSize;
      if (width > newSize.Width && height > newSize.Height)
      {
        double num1 = (double) width / (double) newSize.Width;
        double num2 = (double) height / (double) newSize.Height;
        if (num1 > num2)
        {
          height = height * newSize.Width / width;
          width = newSize.Width;
        }
        if (num1 <= num2)
        {
          width = width * newSize.Height / height;
          height = newSize.Height;
        }
      }
      else if (width > newSize.Width)
      {
        height = height * newSize.Width / width;
        width = newSize.Width;
      }
      else
      {
        width = width * newSize.Height / height;
        height = newSize.Height;
      }
      return new Size(width, height);
    }

    public static Image ResizedImage(Image _img, int width, int height)
    {
      Size newSize = Tools.BestFitSize(_img.Size, new Size(width, height));
      return (Image) new Bitmap(_img, newSize);
    }

    public static void CalculateCardRegions()
    {
      Logger.FuncInit("Tools.CalculateCardRegions");
      if (GameData.form != null)
      {
        TableLayoutColumnStyleCollection columnStyles = GameData.form.tableLayoutPanel.ColumnStyles;
        TableLayoutRowStyleCollection rowStyles = GameData.form.tableLayoutPanel.RowStyles;
        int num1 = (int) ((double) columnStyles[1].Width * (double) GameData.form.tableLayoutPanel.ClientRectangle.Width / 100.0);
        int num2 = (int) ((double) rowStyles[0].Height * (double) GameData.form.tableLayoutPanel.ClientRectangle.Height / 100.0);
        GameData.locOpponent.Location = new Point(GameData.form.tableLayoutPanel.ClientRectangle.Width - num1, 0);
        GameData.locOpponent.Width = num1;
        GameData.locOpponent.Height = num2;
        int num3 = (int) ((double) rowStyles[0].Height * (double) GameData.form.tableLayoutPanel.ClientRectangle.Height / 100.0);
        GameData.locBoard.Location = new Point(GameData.form.tableLayoutPanel.ClientRectangle.Width - num1, GameData.locOpponent.Height);
        GameData.locBoard.Width = num1;
        GameData.locBoard.Height = num3;
        int num4 = (int) ((double) rowStyles[2].Height * (double) GameData.form.tableLayoutPanel.ClientRectangle.Height / 100.0);
        GameData.locPlayer.Location = new Point(GameData.form.tableLayoutPanel.ClientRectangle.Width - num1, GameData.form.tableLayoutPanel.ClientRectangle.Height - num4);
        GameData.locPlayer.Width = num1;
        GameData.locPlayer.Height = num4;
        int num5 = (int) ((double) columnStyles[0].Width * (double) GameData.form.tableLayoutPanel.ClientRectangle.Width / 100.0);
        int num6 = (int) ((double) rowStyles[1].Height * (double) GameData.form.tableLayoutPanel.ClientRectangle.Height / 100.0);
        GameData.locSlot.Location = new Point(0, GameData.locOpponent.Height);
        GameData.locSlot.Width = num5;
        GameData.locSlot.Height = num6;
      }
      Logger.FuncExit("Tools.CalculateCardRegions");
    }

    public static Card GetBiggestCard(Cards cards)
    {
      Card card1 = (Card) null;
      UnoCards unoCards = UnoCards.Back;
      foreach (Card card2 in (ArrayList) cards)
      {
        if (card2.number > unoCards)
        {
          card1 = card2;
          unoCards = card2.number;
        }
      }
      return card1;
    }

    public static Random GetRandomObject()
    {
      return new Random((int) (DateTime.Now.Ticks ^ (long) int.MaxValue));
    }

    public static void FlashError()
    {
      Tools.timer.Interval = 500;
      Tools.timer.Tick += new EventHandler(Tools.timer_Tick);
      Tools.start = DateTime.Now.Ticks;
      Tools.timer.Start();
    }

    private static void timer_Tick(object sender, EventArgs e)
    {
      if ((DateTime.Now.Ticks - Tools.start) / 10000000L > 2L)
      {
        Tools.timer.Stop();
        Tools.timer.Tick -= new EventHandler(Tools.timer_Tick);
      }
      Tools.FlashWindow(GameData.form.Handle, true);
    }
  }
}
