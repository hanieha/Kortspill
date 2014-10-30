using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kortspill;

// -------------------------------------------------------------------------
// The UnitTest class!
// -------------------------------------------------------------------------

namespace KortspillUnitTest
{
  [TestClass]
  public class CardUnitTest
  {
    [TestMethod]
    public void CheckNumberOfCards()
    {
      IDeck deck = new Deck();
      Assert.AreEqual(52, deck.Cards.Count);
    }

    [TestMethod]
    public void CheckNumberOfCardsPerCardType()
    {
      var deck = new Deck();
      Assert.AreEqual(13, deck.Cards.Count(c => c.CardType == CardType.Club));
      Assert.AreEqual(13, deck.Cards.Count(c => c.CardType == CardType.Diamond));
      Assert.AreEqual(13, deck.Cards.Count(c => c.CardType == CardType.Heart));
      Assert.AreEqual(13, deck.Cards.Count(c => c.CardType == CardType.Spades));
    }

    [TestMethod]
    public void CheckTakingMorethan52Cards()
    {
      var deck = new Deck();
      var cards = deck.TakeCards(52);
      Assert.IsNull(deck.TakeCard());
    }

    [TestMethod]
    public void CheckResetCardsPutTheTakenCardBack()
    {
      var deck = new Deck();
      var card = deck.TakeCard();
      Assert.AreEqual(51, deck.Cards.Count);
      deck.Reset();
      Assert.AreEqual(52, deck.Cards.Count);
    }

    [TestMethod]
    public void CheckTheTakenCardIsNotOnDeck()
    {
      var deck = new Deck();
      var takenCard = (Card)deck.TakeCard();
      Assert.IsFalse(deck.Cards.Any(c => c.CardType == takenCard.CardType &&
                                    c.CardNumber == takenCard.CardNumber));
    }

  }
}
