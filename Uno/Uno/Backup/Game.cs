// Decompiled with JetBrains decompiler
// Type: Uno.Game
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System;
using System.Windows.Forms;

namespace Uno
{
  internal class Game
  {
    private static Timer timer = new Timer();
    public static bool Over = false;
    private static bool firstGame = true;
    private static bool gameStarted = false;
    private const int MAX_BEGINING_CARDS = 7;

    public static bool Started
    {
      get
      {
        return Game.gameStarted;
      }
    }

    public static void Init()
    {
      Game.timer.Interval = 200;
      Game.timer.Tick += new EventHandler(Game.timer_Tick);
    }

    private static bool initPlayerData()
    {
      Logger.FuncInit("Game.initPlayerData");
      if (new frmUserData().ShowDialog((IWin32Window) GameData.form) == DialogResult.Cancel)
        return false;
      Logger.FuncExit("Game.initPlayerData");
      return true;
    }

    private static void timer_Tick(object sender, EventArgs e)
    {
      if (GameData.flagDirty)
      {
        GameData.form.Invalidate(true);
        GameData.flagDirty = false;
      }
      if (Game.Over || Logic.PlayerTurn)
        return;
      Logic.MakeOpponentMove();
    }

    public static void StartNewGame()
    {
      Game.timer.Stop();
      Game.clearUp();
      Game.deal();
      Game.distributeCards();
      GameData.flagDirty = true;
      Game.timer.Start();
      Game.throwFirstCard();
    }

    public static void PauseGame()
    {
    }

    public static void ContinueGame()
    {
    }

    public static void AbortGame()
    {
    }

    private static void clearUp()
    {
      GameData.deck.Clear();
      GameData.openCards.Clear();
      GameData.player.Clear();
      GameData.opponnent.Clear();
      GameData.playerScore = GameData.opponentScore = 0;
      Game.gameStarted = true;
      Game.firstGame = false;
      Game.Over = false;
    }

    private static void deal()
    {
      GameData.deck.CreateDeck();
      GameData.deck.Shuffle();
    }

    private static void distributeCards()
    {
      for (int index = 0; index < 7; ++index)
      {
        GameData.player.AddCard(GameData.deck.GetACard());
        GameData.opponnent.AddCard(GameData.deck.GetACard());
      }
    }

    private static void throwFirstCard()
    {
      Card acard = GameData.deck.GetACard();
      GameData.openCards.Add(acard);
      Logic.CheckIfAddCardRequired(acard);
      if (Logic.PlayerTurn)
      {
        if (acard.number != UnoCards.WildCard)
          return;
        Logic.PlayerSelectsNewColor(acard);
        Logic.PlayerTurn = false;
      }
      else
        Logic.OpponentSelectsNewColor();
    }
  }
}
