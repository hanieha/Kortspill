using System;
using System.Collections.Generic;
using System.Linq;

// -------------------------------------------------------------------------
// class Deck inherited from class IDeck
// -------------------------------------------------------------------------
namespace kortspill
{
  public class Deck : IDeck
  {

    public Deck()
    {
      Reset();
    }

    public List<Card> Cards { get; set; }


    //This Method reset the deck by the means of reseting assigned cards and return all 52 cards
    // These 52 cards are combination of two enums (cardtype and cardnumber) by using linq expression

    //return value: list
    public void Reset()
    {
      Cards = Enumerable.Range(1, 4).SelectMany(s => Enumerable.Range(1, 13).Select(c => new Card() { CardType = (CardType)s, CardNumber = (CardNumber)c })).ToList();
    }


    //This method returns list of the cards randomly by use of GUID 
    //GUID is a globally unique identifier (128-bit integer) as is obvious in its name, it can be used to identify items uniquely.
    //It is accessible just by creating new instance of GUID class

    public void Shuffle()
    {
      Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
    }


    //This method can be used to take a card from shuffled or sorted list of cards.
    //It depends on which method you call before to take a card from the cards list! 
    //each time we take a card, the taken card will be removed from list of initial cards (52cards)
    //@return ass
    public Card TakeCard()
    {
      var card = Cards.FirstOrDefault();
      Cards.Remove(card);

      return card;
    }


    //This method can be used to take a card from assigned cards to a hand.
    //each time we take a card, the taken card will be removed from list of initial cards in hand
    //@return ass
    public Card TakeCardFromHand(List<Card> handCards)
    {
      var card = handCards.FirstOrDefault();
      handCards.Remove(card);
      return card;
    }

    //By this method you can decide on the number of cards you want to assign to a hand
    //each time we assign number of cards to a hand, the assigned cards will be removed from list of initial cards (52cards)
    //sets numberof cards
    //@return assignedcards
    public IEnumerable<Card> TakeCards(int numberOfCards)
    {
      var cards = Cards.Take(numberOfCards);

      var takeCards = cards as Card[] ?? cards.ToArray();
      Cards.RemoveAll(takeCards.Contains);

      return takeCards;
    }

    //This method has been used to show the list of cards whenever we want
    public IEnumerable<Card> ShowCards()
    {
      return Cards;
    }

    //This method has been used to sort the assigned cards to the hand by using linq expressions
    //The sorting is first based on card types and then card numbers
    //@return list of sorted assigned cards
    public IEnumerable<Card> SortHandCards(IEnumerable<Card> cards)
    {
      return cards.OrderBy(c => c.CardType).ThenBy(c => c.CardNumber);
    }

    


  }
}
