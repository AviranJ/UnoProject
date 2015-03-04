// Decompiled with JetBrains decompiler
// Type: Uno.Deck
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System;
using System.Collections;

namespace Uno
{
  internal class Deck : ArrayList
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

    public void CreateDeck()
    {
      this.buildDeck();
    }

    public void SetCards(Cards cards)
    {
      foreach (Card card in (ArrayList) cards)
        this.Add((object) card);
    }

    private void buildDeck()
    {
      this.addOnePack();
      this.addOnePack();
    }

    private void addOnePack()
    {
      int off1 = 1;
      int num1 = 0;
      this.Add((object) new Card(UnoCards.DrawFour, off1, (UnoColours) num1));
      int num2 = 15;
      int off2 = off1;
      int num3 = 1;
      int off3 = off2 + num3;
      int num4 = num1;
      this.Add((object) new Card((UnoCards) num2, off2, (UnoColours) num4));
      this.Add((object) new Card(UnoCards.WildCard, off3, (UnoColours) num1));
      int num5 = 13;
      int off4 = off3;
      int num6 = 1;
      int num7 = off4 + num6;
      int num8 = num1;
      int num9 = 1;
      int num10 = num8 + num9;
      this.Add((object) new Card((UnoCards) num5, off4, (UnoColours) num8));
      int num11 = 10;
      int off5 = num7;
      int num12 = 1;
      int num13 = off5 + num12;
      int num14 = num10;
      this.Add((object) new Card((UnoCards) num11, off5, (UnoColours) num14));
      int num15 = 11;
      int off6 = num13;
      int num16 = 1;
      int num17 = off6 + num16;
      int num18 = num10;
      this.Add((object) new Card((UnoCards) num15, off6, (UnoColours) num18));
      int num19 = 12;
      int off7 = num17;
      int num20 = 1;
      int num21 = off7 + num20;
      int num22 = num10;
      this.Add((object) new Card((UnoCards) num19, off7, (UnoColours) num22));
      int num23 = 0;
      int off8 = num21;
      int num24 = 1;
      int num25 = off8 + num24;
      int num26 = num10;
      this.Add((object) new Card((UnoCards) num23, off8, (UnoColours) num26));
      int num27 = 1;
      int off9 = num25;
      int num28 = 1;
      int num29 = off9 + num28;
      int num30 = num10;
      this.Add((object) new Card((UnoCards) num27, off9, (UnoColours) num30));
      int num31 = 2;
      int off10 = num29;
      int num32 = 1;
      int num33 = off10 + num32;
      int num34 = num10;
      this.Add((object) new Card((UnoCards) num31, off10, (UnoColours) num34));
      int num35 = 3;
      int off11 = num33;
      int num36 = 1;
      int num37 = off11 + num36;
      int num38 = num10;
      this.Add((object) new Card((UnoCards) num35, off11, (UnoColours) num38));
      int num39 = 4;
      int off12 = num37;
      int num40 = 1;
      int num41 = off12 + num40;
      int num42 = num10;
      this.Add((object) new Card((UnoCards) num39, off12, (UnoColours) num42));
      int num43 = 5;
      int off13 = num41;
      int num44 = 1;
      int num45 = off13 + num44;
      int num46 = num10;
      this.Add((object) new Card((UnoCards) num43, off13, (UnoColours) num46));
      int num47 = 6;
      int off14 = num45;
      int num48 = 1;
      int num49 = off14 + num48;
      int num50 = num10;
      this.Add((object) new Card((UnoCards) num47, off14, (UnoColours) num50));
      int num51 = 7;
      int off15 = num49;
      int num52 = 1;
      int num53 = off15 + num52;
      int num54 = num10;
      this.Add((object) new Card((UnoCards) num51, off15, (UnoColours) num54));
      int num55 = 8;
      int off16 = num53;
      int num56 = 1;
      int num57 = off16 + num56;
      int num58 = num10;
      this.Add((object) new Card((UnoCards) num55, off16, (UnoColours) num58));
      int num59 = 9;
      int off17 = num57;
      int num60 = 1;
      int num61 = off17 + num60;
      int num62 = num10;
      int num63 = 1;
      int num64 = num62 + num63;
      this.Add((object) new Card((UnoCards) num59, off17, (UnoColours) num62));
      int num65 = 10;
      int off18 = num61;
      int num66 = 1;
      int num67 = off18 + num66;
      int num68 = num64;
      this.Add((object) new Card((UnoCards) num65, off18, (UnoColours) num68));
      int num69 = 11;
      int off19 = num67;
      int num70 = 1;
      int num71 = off19 + num70;
      int num72 = num64;
      this.Add((object) new Card((UnoCards) num69, off19, (UnoColours) num72));
      int num73 = 12;
      int off20 = num71;
      int num74 = 1;
      int num75 = off20 + num74;
      int num76 = num64;
      this.Add((object) new Card((UnoCards) num73, off20, (UnoColours) num76));
      int num77 = 0;
      int off21 = num75;
      int num78 = 1;
      int num79 = off21 + num78;
      int num80 = num64;
      this.Add((object) new Card((UnoCards) num77, off21, (UnoColours) num80));
      int num81 = 1;
      int off22 = num79;
      int num82 = 1;
      int num83 = off22 + num82;
      int num84 = num64;
      this.Add((object) new Card((UnoCards) num81, off22, (UnoColours) num84));
      int num85 = 2;
      int off23 = num83;
      int num86 = 1;
      int num87 = off23 + num86;
      int num88 = num64;
      this.Add((object) new Card((UnoCards) num85, off23, (UnoColours) num88));
      int num89 = 3;
      int off24 = num87;
      int num90 = 1;
      int num91 = off24 + num90;
      int num92 = num64;
      this.Add((object) new Card((UnoCards) num89, off24, (UnoColours) num92));
      int num93 = 4;
      int off25 = num91;
      int num94 = 1;
      int num95 = off25 + num94;
      int num96 = num64;
      this.Add((object) new Card((UnoCards) num93, off25, (UnoColours) num96));
      int num97 = 5;
      int off26 = num95;
      int num98 = 1;
      int num99 = off26 + num98;
      int num100 = num64;
      this.Add((object) new Card((UnoCards) num97, off26, (UnoColours) num100));
      int num101 = 6;
      int off27 = num99;
      int num102 = 1;
      int num103 = off27 + num102;
      int num104 = num64;
      this.Add((object) new Card((UnoCards) num101, off27, (UnoColours) num104));
      int num105 = 7;
      int off28 = num103;
      int num106 = 1;
      int num107 = off28 + num106;
      int num108 = num64;
      this.Add((object) new Card((UnoCards) num105, off28, (UnoColours) num108));
      int num109 = 8;
      int off29 = num107;
      int num110 = 1;
      int num111 = off29 + num110;
      int num112 = num64;
      this.Add((object) new Card((UnoCards) num109, off29, (UnoColours) num112));
      int num113 = 9;
      int off30 = num111;
      int num114 = 1;
      int num115 = off30 + num114;
      int num116 = num64;
      int num117 = 1;
      int num118 = num116 + num117;
      this.Add((object) new Card((UnoCards) num113, off30, (UnoColours) num116));
      int num119 = 10;
      int off31 = num115;
      int num120 = 1;
      int num121 = off31 + num120;
      int num122 = num118;
      this.Add((object) new Card((UnoCards) num119, off31, (UnoColours) num122));
      int num123 = 11;
      int off32 = num121;
      int num124 = 1;
      int num125 = off32 + num124;
      int num126 = num118;
      this.Add((object) new Card((UnoCards) num123, off32, (UnoColours) num126));
      int num127 = 12;
      int off33 = num125;
      int num128 = 1;
      int num129 = off33 + num128;
      int num130 = num118;
      this.Add((object) new Card((UnoCards) num127, off33, (UnoColours) num130));
      int num131 = 0;
      int off34 = num129;
      int num132 = 1;
      int num133 = off34 + num132;
      int num134 = num118;
      this.Add((object) new Card((UnoCards) num131, off34, (UnoColours) num134));
      int num135 = 1;
      int off35 = num133;
      int num136 = 1;
      int num137 = off35 + num136;
      int num138 = num118;
      this.Add((object) new Card((UnoCards) num135, off35, (UnoColours) num138));
      int num139 = 2;
      int off36 = num137;
      int num140 = 1;
      int num141 = off36 + num140;
      int num142 = num118;
      this.Add((object) new Card((UnoCards) num139, off36, (UnoColours) num142));
      int num143 = 3;
      int off37 = num141;
      int num144 = 1;
      int num145 = off37 + num144;
      int num146 = num118;
      this.Add((object) new Card((UnoCards) num143, off37, (UnoColours) num146));
      int num147 = 4;
      int off38 = num145;
      int num148 = 1;
      int num149 = off38 + num148;
      int num150 = num118;
      this.Add((object) new Card((UnoCards) num147, off38, (UnoColours) num150));
      int num151 = 5;
      int off39 = num149;
      int num152 = 1;
      int num153 = off39 + num152;
      int num154 = num118;
      this.Add((object) new Card((UnoCards) num151, off39, (UnoColours) num154));
      int num155 = 6;
      int off40 = num153;
      int num156 = 1;
      int num157 = off40 + num156;
      int num158 = num118;
      this.Add((object) new Card((UnoCards) num155, off40, (UnoColours) num158));
      int num159 = 7;
      int off41 = num157;
      int num160 = 1;
      int num161 = off41 + num160;
      int num162 = num118;
      this.Add((object) new Card((UnoCards) num159, off41, (UnoColours) num162));
      int num163 = 8;
      int off42 = num161;
      int num164 = 1;
      int num165 = off42 + num164;
      int num166 = num118;
      this.Add((object) new Card((UnoCards) num163, off42, (UnoColours) num166));
      int num167 = 9;
      int off43 = num165;
      int num168 = 1;
      int num169 = off43 + num168;
      int num170 = num118;
      int num171 = 1;
      int num172 = num170 + num171;
      this.Add((object) new Card((UnoCards) num167, off43, (UnoColours) num170));
      int num173 = 10;
      int off44 = num169;
      int num174 = 1;
      int num175 = off44 + num174;
      int num176 = num172;
      this.Add((object) new Card((UnoCards) num173, off44, (UnoColours) num176));
      int num177 = 11;
      int off45 = num175;
      int num178 = 1;
      int num179 = off45 + num178;
      int num180 = num172;
      this.Add((object) new Card((UnoCards) num177, off45, (UnoColours) num180));
      int num181 = 12;
      int off46 = num179;
      int num182 = 1;
      int num183 = off46 + num182;
      int num184 = num172;
      this.Add((object) new Card((UnoCards) num181, off46, (UnoColours) num184));
      int num185 = 0;
      int off47 = num183;
      int num186 = 1;
      int num187 = off47 + num186;
      int num188 = num172;
      this.Add((object) new Card((UnoCards) num185, off47, (UnoColours) num188));
      int num189 = 1;
      int off48 = num187;
      int num190 = 1;
      int num191 = off48 + num190;
      int num192 = num172;
      this.Add((object) new Card((UnoCards) num189, off48, (UnoColours) num192));
      int num193 = 2;
      int off49 = num191;
      int num194 = 1;
      int num195 = off49 + num194;
      int num196 = num172;
      this.Add((object) new Card((UnoCards) num193, off49, (UnoColours) num196));
      int num197 = 3;
      int off50 = num195;
      int num198 = 1;
      int num199 = off50 + num198;
      int num200 = num172;
      this.Add((object) new Card((UnoCards) num197, off50, (UnoColours) num200));
      int num201 = 4;
      int off51 = num199;
      int num202 = 1;
      int num203 = off51 + num202;
      int num204 = num172;
      this.Add((object) new Card((UnoCards) num201, off51, (UnoColours) num204));
      int num205 = 5;
      int off52 = num203;
      int num206 = 1;
      int num207 = off52 + num206;
      int num208 = num172;
      this.Add((object) new Card((UnoCards) num205, off52, (UnoColours) num208));
      int num209 = 6;
      int off53 = num207;
      int num210 = 1;
      int num211 = off53 + num210;
      int num212 = num172;
      this.Add((object) new Card((UnoCards) num209, off53, (UnoColours) num212));
      int num213 = 7;
      int off54 = num211;
      int num214 = 1;
      int num215 = off54 + num214;
      int num216 = num172;
      this.Add((object) new Card((UnoCards) num213, off54, (UnoColours) num216));
      int num217 = 8;
      int off55 = num215;
      int num218 = 1;
      int num219 = off55 + num218;
      int num220 = num172;
      this.Add((object) new Card((UnoCards) num217, off55, (UnoColours) num220));
      int num221 = 9;
      int off56 = num219;
      int num222 = 1;
      int num223 = off56 + num222;
      int num224 = num172;
      int num225 = 1;
      int num226 = num224 + num225;
      this.Add((object) new Card((UnoCards) num221, off56, (UnoColours) num224));
    }

    public void Shuffle()
    {
      Random randomObject = Tools.GetRandomObject();
      for (int index1 = 0; index1 < this.Count; ++index1)
      {
        int index2 = randomObject.Next(this.Count);
        int index3 = randomObject.Next(this.Count);
        Card card = this[index2];
        this[index2] = base[index3];
        this[index3] = (object) card;
      }
    }

    public Card GetACard()
    {
      if (this.Count <= 0)
        throw new Exception("Deck is empty.");
      int index = Tools.GetRandomObject().Next(this.Count);
      Card card = this[index];
      this.RemoveAt(index);
      return card;
    }

    public string GetDeck()
    {
      string str = "";
      foreach (Card card in (ArrayList) this)
        str = str + card.ToString() + "\r\n";
      return str;
    }
  }
}
