// Decompiled with JetBrains decompiler
// Type: Uno.Player
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

namespace Uno
{
  internal class Player
  {
    public Cards cards = new Cards();

    public void AddCard(Card c)
    {
      this.cards.Add(c);
    }

    public void Clear()
    {
      this.cards.Clear();
    }
  }
}
