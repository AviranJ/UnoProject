// Decompiled with JetBrains decompiler
// Type: Uno.OpenDeck
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System.Collections;

namespace Uno
{
  internal class OpenDeck : ArrayList
  {
    public Card this[int index]
    {
      get
      {
        if (index < this.Count)
          return (Card) base[index];
        return (Card) null;
      }
    }

    public void Add(Card c)
    {
      this.Add((object) c);
      GameData.RunningColor = c.color;
    }

    public override void Clear()
    {
      base.Clear();
      GameData.form.lblColorRunning.Text = "";
    }

    public Cards GetCards()
    {
      Cards cards = new Cards();
      foreach (Card card in (ArrayList) this)
        cards.Add(card);
      return cards;
    }

    public Card LastCard()
    {
      if (this.Count > 0)
        return (Card) base[this.Count - 1];
      return (Card) null;
    }
  }
}
