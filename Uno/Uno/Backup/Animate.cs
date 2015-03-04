// Decompiled with JetBrains decompiler
// Type: Uno.Animate
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Uno
{
  internal class Animate
  {
    private static Card _card = (Card) null;
    private static Rectangle _destRect = new Rectangle();
    private static Image _cardImage = (Image) null;
    private static int _stepX = 0;
    private static int _stepY = 0;
    private static int _dx = 0;
    private static Graphics _graphicsTable = (Graphics) null;
    private static Bitmap _layoutBackBmp = (Bitmap) null;
    private static bool _animationFnished = true;
    private const int STEP = 30;

    public static void Move(Card card, Point source, Point dest)
    {
      Animate.Move(card, source.X, source.Y, dest.X, dest.Y);
    }

    public static void Move(Card card, Control source, Control dest)
    {
      Animate.Move(card, source.Left, source.Top, dest.Left, dest.Top);
    }

    public static void Move(Card card, int sourceX, int sourceY, int destX, int destY)
    {
      Animate.preAnimate(card, sourceX, sourceY, destX, destY);
      Animate.doAnimate();
      Animate.postAnimate();
    }

    private static void preAnimate(Card card, int sourceX, int sourceY, int destX, int destY)
    {
      Animate._card = card;
      Animate._layoutBackBmp = new Bitmap(GameData.form.tableLayoutPanel.ClientRectangle.Width, GameData.form.tableLayoutPanel.ClientRectangle.Height);
      GameData.form.tableLayoutPanel.DrawToBitmap(Animate._layoutBackBmp, GameData.form.tableLayoutPanel.ClientRectangle);
      Animate._cardImage = Tools.ResizedImage(Animate._card.cardImage, GameData.locSlot.Width, GameData.locSlot.Height);
      Animate._dx = destX - sourceX;
      double num = (double) (destY - sourceY) / (double) Animate._dx;
      Animate._stepX = Animate._dx > 0 ? 30 : -30;
      if (Math.Abs(Animate._dx) < 30)
        Animate._stepX = Animate._dx;
      Animate._stepY = (int) (30.0 * num);
      Animate._dx = Math.Abs(Animate._dx);
      Animate._destRect = new Rectangle(sourceX, sourceY, Animate._cardImage.Width, Animate._cardImage.Height);
      Animate._graphicsTable = GameData.form.tableLayoutPanel.CreateGraphics();
      Animate._animationFnished = false;
    }

    private static void doAnimate()
    {
      while (!Animate._animationFnished)
      {
        Bitmap bitmap = new Bitmap((Image) Animate._layoutBackBmp);
        Graphics.FromImage((Image) bitmap).DrawImage(Animate._cardImage, Animate._destRect);
        Animate._destRect.Offset(Animate._stepX, Animate._stepY);
        Animate._dx -= 30;
        if (Animate._dx < 30)
          Animate._animationFnished = true;
        Animate._graphicsTable.DrawImage((Image) bitmap, 0, 0);
      }
    }

    private static void postAnimate()
    {
      if (Animate._graphicsTable == null)
        return;
      Animate._graphicsTable.Dispose();
      Animate._graphicsTable = (Graphics) null;
    }
  }
}
