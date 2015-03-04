// Decompiled with JetBrains decompiler
// Type: Uno.Logic
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Uno
{
  internal class Logic
  {
    private static int _numberOfDrawnCards = 0;
    private static bool _thinking = false;
    private static bool bPlaying = false;
    private static bool playerTurn = true;

    public static bool PlayerTurn
    {
      get
      {
        return Logic.playerTurn;
      }
      set
      {
        Logic.playerTurn = value;
        Logic._numberOfDrawnCards = 0;
      }
    }

    private static Card nextCardToThrow(Cards cards)
    {
      Logger.FuncInit("Logic.nextCardToThrow");
      Card card1 = (Card) null;
      Card card2 = GameData.openCards.LastCard();
      if (card2 != null)
      {
        Cards cards1 = new Cards();
        Cards cards2 = new Cards();
        Cards cards3 = new Cards();
        foreach (Card card3 in (ArrayList) cards)
        {
          if (card3.color == UnoColours.NoColor)
          {
            cards3.Add(card3);
          }
          else
          {
            if (GameData.RunningColor == card3.color)
              cards1.Add(card3);
            if (card2.number == card3.number)
              cards2.Add(card3);
          }
        }
        if (GameData.RunningColor != UnoColours.NoColor)
        {
          if (cards1.Count > 0)
            card1 = Tools.GetBiggestCard(cards1);
          else if (cards2.Count > 0)
          {
            if (cards3.Count > 0)
            {
              card1 = Tools.GetBiggestCard(cards3);
            }
            else
            {
              Random randomObject = Tools.GetRandomObject();
              card1 = cards2[randomObject.Next(cards2.Count)];
            }
          }
          else if (cards3.Count > 0)
            card1 = Tools.GetBiggestCard(cards3);
        }
        else
          card1 = Tools.GetBiggestCard(cards);
      }
      Logger.FuncExit("Logic.nextCardToThrow");
      return card1;
    }

    public static void CheckIfAddCardRequired(Card card)
    {
      Logger.FuncInit("Logic.CheckIfAddCardRequired");
      switch (card.number)
      {
        case UnoCards.Plus2:
        case UnoCards.DrawTwo:
          if (!Logic.PlayerTurn)
          {
            Logic.AddCardToPlayer();
            Logic.AddCardToPlayer();
            break;
          }
          Logic.addCardToOpponent();
          Logic.addCardToOpponent();
          break;
        case UnoCards.DrawFour:
          if (!Logic.PlayerTurn)
          {
            Logic.AddCardToPlayer();
            Logic.AddCardToPlayer();
            Logic.AddCardToPlayer();
            Logic.AddCardToPlayer();
            break;
          }
          Logic.addCardToOpponent();
          Logic.addCardToOpponent();
          Logic.addCardToOpponent();
          Logic.addCardToOpponent();
          break;
      }
      Logger.FuncExit("Logic.CheckIfAddCardRequired");
    }

    private static void calculateTotalScore()
    {
      GameData.TotalPlayerScore += GameData.playerScore;
      GameData.TotalOpponentScore += GameData.opponentScore;
    }

    public static void MakeOpponentMove()
    {
      Logger.FuncInit("Logic.MakeOpponentMove");
      if (!Logic._thinking)
      {
        Logic._thinking = true;
        Logic.moveOpponent();
        Logic._thinking = false;
        Logic.PlayerTurn = true;
      }
      Logger.FuncExit("Logic.MakeOpponentMove");
    }

    private static void checkOpponentWin()
    {
      if (GameData.opponnent.cards.Count != 0 || Game.Over)
        return;
      Game.Over = true;
      GameData.playerScore = 0;
      foreach (Card card in (ArrayList) GameData.player.cards)
        GameData.playerScore += Tools.GetPoint(card);
      Logic.calculateTotalScore();
      int num = (int) MessageBox.Show("You lose by " + GameData.playerScore.ToString() + ".", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private static void moveOpponent()
    {
      Logger.FuncInit("Logic.moveOpponent");
      Card card = Logic.nextCardToThrow(GameData.opponnent.cards);
      if (card == null)
      {
        if (Logic._numberOfDrawnCards <= 0)
        {
          Logic.addCardToOpponent();
          ++Logic._numberOfDrawnCards;
          Logic.moveOpponent();
          Logic._numberOfDrawnCards = 0;
        }
      }
      else
      {
        Logic.putDownOpponentCard(card);
        Logic.checkOpponentWin();
        if (card.number > UnoCards.Nine && card.number <= UnoCards.DrawFour)
        {
          Logic.CheckIfAddCardRequired(card);
          if (card.number >= UnoCards.WildCard && card.number <= UnoCards.DrawFour)
            Logic.OpponentSelectsNewColor();
          if (card.number != UnoCards.WildCard)
          {
            Logic._numberOfDrawnCards = 0;
            Logic.moveOpponent();
          }
        }
      }
      Logger.FuncExit("Logic.moveOpponent");
    }

    public static void OpponentSelectsNewColor()
    {
      GameData.RunningColor = (UnoColours) (Tools.GetRandomObject().Next(4) + 1);
    }

    private static void putDownOpponentCard(Card nextCard)
    {
      Logger.FuncInit("Logic.putDownOpponentCard");
      GameData.opponnent.cards.Remove((object) nextCard);
      Animate.Move(nextCard, GameData.locOpponent.Left, GameData.locOpponent.Top, GameData.locBoard.Left + (GameData.locBoard.Width - nextCard.cardImage.Width) / 2, GameData.locBoard.Top);
      GameData.openCards.Add(nextCard);
      GameData.flagDirty = true;
      Logger.FuncExit("Logic.putDownOpponentCard");
    }

    private static void addCardToOpponent()
    {
      if (GameData.deck.Count > 0)
      {
        Animate.Move(GameData.backFacingCard, new Point(GameData.locSlot.Location.X + (GameData.locSlot.Width - GameData.backFacingCard.cardImage.Width) / 2, GameData.locSlot.Location.Y), GameData.locOpponent.Location);
        GameData.opponnent.AddCard(GameData.deck.GetACard());
      }
      else
        Logic.reloadDeckFromOpenCards();
      GameData.flagDirty = true;
    }

    private static void reloadDeckFromOpenCards()
    {
      Logger.FuncInit("Logic.reloadDeckFromOpenCards");
      if (GameData.openCards.Count > 1)
      {
        GameData.deck.SetCards(GameData.openCards.GetCards());
        GameData.openCards.Clear();
        GameData.openCards.Add(GameData.deck.GetACard());
      }
      Logger.FuncExit("Logic.reloadDeckFromOpenCards");
    }

    public static void Play(object sender, MouseEventArgs e)
    {
      Logger.FuncInit("Logic.Play");
      if (!Logic.bPlaying)
      {
        Logic.bPlaying = true;
        if (GameData.locSlot.Contains(e.Location))
        {
          if (Logic._numberOfDrawnCards < 1)
          {
            Logic.AddCardToPlayer();
            ++Logic._numberOfDrawnCards;
            GameData.form.btnPass.Enabled = true;
          }
        }
        else if (GameData.locPlayer.Contains(e.Location))
        {
          GameData.form.btnPass.Enabled = false;
          if (!Logic.playTheCard(sender, e))
          {
            Logic.PlayerTurn = false;
            GameData.form.btnPass.Enabled = false;
          }
          else
            Logic._numberOfDrawnCards = 0;
        }
        Logic.bPlaying = false;
      }
      Logger.FuncExit("Logic.Play");
    }

    private static int getPlayerCardIndex(MouseEventArgs e)
    {
      int num1 = -1;
      Size size = Tools.BestFitSize(GameData.backFacingCard.cardImage.Size, GameData.locPlayer.Size);
      int num2 = size.Width / 4;
      int num3 = (GameData.player.cards.Count - 1) * num2 + size.Width;
      int num4 = e.X - GameData.locPlayer.X;
      if (num4 <= num3)
      {
        num1 = num4 / num2;
        if (num4 % num2 > 0)
          ++num1;
        if (num1 > GameData.player.cards.Count)
          num1 = GameData.player.cards.Count;
      }
      return num1;
    }

    private static bool playTheCard(object sender, MouseEventArgs e)
    {
      Logger.FuncInit("Logic.playTheCard");
      bool flag = true;
      int playerCardIndex = Logic.getPlayerCardIndex(e);
      if (playerCardIndex > -1)
      {
        Card card = GameData.player.cards[playerCardIndex - 1];
        if (Logic.canThrow(card))
        {
          Logic.putDownCardOfPlayer(card);
          Logic.CheckIfAddCardRequired(card);
          Logic.checkpointPlayerWin();
          Logic.PlayerSelectsNewColor(card);
          if (card.number <= UnoCards.Nine || card.number == UnoCards.WildCard)
            flag = false;
        }
        else
          Tools.FlashError();
      }
      Logger.FuncExit("Logic.playTheCard");
      return flag;
    }

    public static void PlayerSelectsNewColor(Card card)
    {
      if (card.number != UnoCards.WildCard)
        return;
      frmColorSelection frmColorSelection = new frmColorSelection();
      int num = (int) frmColorSelection.ShowDialog();
      GameData.RunningColor = frmColorSelection.SelectedColor;
      frmColorSelection.Dispose();
    }

    private static void checkpointPlayerWin()
    {
      if (GameData.player.cards.Count != 0)
        return;
      Game.Over = true;
      GameData.opponentScore = 0;
      foreach (Card card in (ArrayList) GameData.opponnent.cards)
        GameData.opponentScore += Tools.GetPoint(card);
      Logic.calculateTotalScore();
      int num = (int) MessageBox.Show("You win by " + GameData.opponentScore.ToString() + "!!", "Wow!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private static bool canThrow(Card card)
    {
      bool flag = false;
      Card card1 = GameData.openCards.LastCard();
      if (card1 != null && (GameData.RunningColor == UnoColours.NoColor || GameData.RunningColor == card.color || (card1.number == card.number || card.color == UnoColours.NoColor)))
        flag = true;
      return flag;
    }

    private static void putDownCardOfPlayer(Card nextCard)
    {
      GameData.player.cards.Remove((object) nextCard);
      Animate.Move(nextCard, GameData.locPlayer.Left, GameData.locPlayer.Top, GameData.locBoard.Left + (GameData.locBoard.Width - nextCard.cardImage.Width) / 2, GameData.locBoard.Top);
      GameData.openCards.Add(nextCard);
      GameData.flagDirty = true;
    }

    public static void AddCardToPlayer()
    {
      if (GameData.deck.Count > 0)
      {
        Animate.Move(GameData.backFacingCard, new Point(GameData.locSlot.Location.X + (GameData.locSlot.Width - GameData.backFacingCard.cardImage.Width) / 2, GameData.locSlot.Location.Y), GameData.locPlayer.Location);
        GameData.player.AddCard(GameData.deck.GetACard());
      }
      else
        Logic.reloadDeckFromOpenCards();
      GameData.flagDirty = true;
    }
  }
}
