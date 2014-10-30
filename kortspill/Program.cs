using System;
using System.Linq;

// -------------------------------------------------------------------------
// The main class!
// -------------------------------------------------------------------------

namespace kortspill
{
  class Program
  {
    private static void Main(string[] args)
    {
      
      IDeck deck = new Deck();
      Console.WriteLine("******* PLAYING CARDS BY HANIEH *******");
      Console.WriteLine("\n");


      Console.WriteLine("******* List Of Cards *******");
      deck.Reset();
      foreach (var c in deck.ShowCards())
      {
        Console.WriteLine(c.CardType + "--" + c.CardNumber);
      }


      Console.WriteLine("\n");
      Console.WriteLine("******* Suffle Cards *******");
      deck.Shuffle();
      foreach (var c in deck.ShowCards())
      {
        Console.WriteLine(c.CardType + "--" + c.CardNumber);
      }

      Console.WriteLine("\n");
      Console.WriteLine("******* Take a card *******");
      var card = deck.TakeCard();
      Console.WriteLine(card.CardType + "--" + card.CardNumber);

      Console.WriteLine("\n");
      Console.WriteLine("******* Take 5 cards & assign to 2 hands *******");
      var hand1 = deck.TakeCards(5);
      var hand2 = deck.TakeCards(5);


      Console.WriteLine("\n");
      Console.WriteLine("******* Hand 1 *******");
      foreach (var c in hand1)
      {
        Console.WriteLine("hand 1: " + c.CardType + "----" + c.CardNumber);
      }


      Console.WriteLine("\n");
      Console.WriteLine("******* Hand 2 *******");
      foreach (var c in hand2)
      {
        Console.WriteLine("hand 2: " + c.CardType + "----" + c.CardNumber);
      }

      Console.WriteLine("\n");
      Console.WriteLine("******* Sort Hand 1 Cards *******");
      var sortedHand1 = deck.SortHandCards(hand1);
      foreach (var sh in sortedHand1)
      {
        Console.WriteLine("hand 1: " + sh.CardType + "----" + sh.CardNumber);
      }

      Console.WriteLine("\n");
      Console.WriteLine("******* Sort Hand 2 Cards *******");
      var sortedHand2 = deck.SortHandCards(hand2);
      foreach (var sh in sortedHand2)
      {
        Console.WriteLine("hand 2: " + sh.CardType + "----" + sh.CardNumber);
      }

      Console.WriteLine("******* END *******");

    }

  }
}
