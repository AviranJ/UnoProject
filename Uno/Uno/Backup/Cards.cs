// Decompiled with JetBrains decompiler
// Type: Uno.Cards
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System.Collections;

namespace Uno
{
  internal class Cards : ArrayList
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

    public void Add(Card card)
    {
      int firstPosOfColor = this.getFirstPosOfColor(card);
      if (firstPosOfColor == -1)
      {
        this.Add((object) card);
      }
      else
      {
        int numberGroupedByColor = this.getPosByNumberGroupedByColor(card, firstPosOfColor);
        if (numberGroupedByColor == this.Count)
          this.Add((object) card);
        else
          this.Insert(numberGroupedByColor, (object) card);
      }
    }

    private int getFirstPosOfColor(Card card)
    {
      bool flag = false;
      int num = 0;
      foreach (Card card1 in (ArrayList) this)
      {
        if (card1.color == card.color)
        {
          flag = true;
          break;
        }
        ++num;
      }
      if (flag)
        return num;
      return -1;
    }

    private int getPosByNumberGroupedByColor(Card card, int startIndex)
    {
      int num = startIndex;
      for (int index = startIndex; index < this.Count && this[index].color == card.color; ++index)
      {
        if (this[index].number < card.number)
          ++num;
      }
      return num;
    }
  }
}
