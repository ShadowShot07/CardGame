using System.Collections.Generic;
using UnityEngine;

namespace Dakard.Cards
{
   public class DeckHandler : MonoBehaviour
   {
      [SerializeField] private DeckAsset deckAsset = null;
      [SerializeField] private int cardsInHand = 5; //Move to config

      private List<Card> _deck = new List<Card>(); // Network
      private OrderCards _orderCards;
      private Card _selectedCard; //Network

      private void Awake()
      {
         _orderCards = GetComponent<OrderCards>();
         //Get random cards
         SetupCards();
      }

      private void SetupCards()
      {
         StartCoroutine(_orderCards.InstantiateCards(cardsInHand, deckAsset));
         DeckEventSystem.Instance.PlaceCard += CheckCard;
         DeckEventSystem.Instance.OnSelectedCard += SetSelectedCard;
      }

      private void CheckCard(BoardManager boardManager)
      {
         if (_selectedCard != null)
         {
            boardManager.PlaceCard(_selectedCard);
            RemoveFromDeck(_selectedCard);
         }
      }

      private void SetSelectedCard(Card card)
      {
         _selectedCard = card;
      }

      private void AddToDeck(Card card)
      {
         _deck.Add(card);
      }

      private void RemoveFromDeck(Card card)
      {
         _deck.Remove(card);
      }
   }
}
