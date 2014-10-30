using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// -------------------------------------------------------------------------
// Interface til Deck class
// -------------------------------------------------------------------------
namespace kortspill
{
  public interface IDeck
  {
    List<Card> Cards { get; set; }
    void Reset();
    void Shuffle();

    Card TakeCard();
    Card TakeCardFromHand(List<Card> handCards);
    IEnumerable<Card> TakeCards(int cards);

    IEnumerable<Card> ShowCards();
    IEnumerable<Card> SortHandCards(IEnumerable<Card> cards);

  }
}
