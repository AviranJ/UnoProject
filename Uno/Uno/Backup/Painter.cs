// Decompiled with JetBrains decompiler
// Type: Uno.Painter
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System.Drawing;
using System.Windows.Forms;

namespace Uno
{
  internal class Painter
  {
    private static bool isPainting;

    public static void PaintCards(object sender, PaintEventArgs e)
    {
      if (Painter.isPainting)
        return;
      Painter.isPainting = true;
      if (GameData.openCards.Count > 0)
        Painter.paintSourceDeck(sender, e);
      else
        Painter.paintSourceDeckEmpty(sender, e);
      Painter.paintOpponent(sender, e);
      Painter.paintPlayer(sender, e);
      Painter.paintOpenBoard(sender, e);
      Painter.isPainting = false;
    }

    private static void paintSourceDeck(object sender, PaintEventArgs e)
    {
      Image image = Tools.ResizedImage(GameData.backFacingCard.cardImage, GameData.locSlot.Width, GameData.locSlot.Height);
      Rectangle rect = new Rectangle(GameData.locSlot.Left, GameData.locSlot.Top, image.Width, image.Height);
      rect.Offset((GameData.locSlot.Width - image.Width) / 2, (GameData.locSlot.Height - image.Height) / 2);
      e.Graphics.DrawImage(image, rect);
    }

    private static void paintSourceDeckEmpty(object sender, PaintEventArgs e)
    {
      Rectangle rect = GameData.locSlot;
      rect.Inflate(1, 1);
      SolidBrush solidBrush = new SolidBrush(GameData.form.tableLayoutPanel.BackColor);
      e.Graphics.FillRectangle((Brush) solidBrush, rect);
    }

    private static void paintOpponent(object sender, PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      if (GameData.opponnent.cards.Count <= 0)
        return;
      Image image = Tools.ResizedImage(GameData.backFacingCard.cardImage, GameData.locOpponent.Width, GameData.locOpponent.Height);
      int x = image.Width / 4;
      Rectangle rect = new Rectangle(GameData.locOpponent.Left, GameData.locOpponent.Top, image.Width, image.Height);
      for (int index = 0; index < GameData.opponnent.cards.Count; ++index)
      {
        graphics.DrawImage(image, rect);
        rect.Offset(x, 0);
      }
    }

    private static void _showOpponentCards(object sender, PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      if (GameData.opponnent.cards.Count <= 0)
        return;
      Image image1 = Tools.ResizedImage(GameData.backFacingCard.cardImage, GameData.locOpponent.Width, GameData.locOpponent.Height);
      int x = image1.Width / 4;
      Rectangle rect = new Rectangle(GameData.locOpponent.Left, GameData.locOpponent.Top, image1.Width, image1.Height);
      for (int index = 0; index < GameData.opponnent.cards.Count; ++index)
      {
        Image image2 = Tools.ResizedImage(GameData.opponnent.cards[index].cardImage, GameData.locOpponent.Width, GameData.locOpponent.Height);
        graphics.DrawImage(image2, rect);
        rect.Offset(x, 0);
      }
    }

    private static void paintPlayer(object sender, PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      if (GameData.player.cards.Count <= 0)
        return;
      Image image1 = Tools.ResizedImage(GameData.backFacingCard.cardImage, GameData.locPlayer.Width, GameData.locPlayer.Height);
      int x = image1.Width / 4;
      Rectangle rect = new Rectangle(GameData.locPlayer.Left, GameData.locPlayer.Top, image1.Width, image1.Height);
      for (int index = 0; index < GameData.player.cards.Count; ++index)
      {
        Image image2 = Tools.ResizedImage(GameData.player.cards[index].cardImage, GameData.locPlayer.Width, GameData.locPlayer.Height);
        graphics.DrawImage(image2, rect);
        rect.Offset(x, 0);
      }
    }

    private static void paintOpenBoard(object sender, PaintEventArgs e)
    {
      if (GameData.openCards.Count <= 0)
        return;
      Image image = Tools.ResizedImage(GameData.openCards[GameData.openCards.Count - 1].cardImage, GameData.locBoard.Width, GameData.locBoard.Height);
      Rectangle rect = new Rectangle(GameData.locBoard.Left, GameData.locBoard.Top, image.Width, image.Height);
      rect.Offset((GameData.locBoard.Width - image.Width) / 2, (GameData.locBoard.Height - image.Height) / 2);
      e.Graphics.DrawImage(image, rect);
    }
  }
}
