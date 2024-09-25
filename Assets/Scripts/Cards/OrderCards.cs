using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = System.Random;

namespace Dakard.Cards
{
	public class OrderCards : MonoBehaviour
	{
		private Random _random = new();

		//TODO: Turn this into DeckHolderAsset and pick deck type depending on enemy likes.
		[SerializeField] private GameObject baseCard = null;

		private List<GameObject> items = new List<GameObject>();
		[SerializeField] private Transform startLocation = null;
		[SerializeField] private Transform cardPanel = null;
		public float howManyAdded; // How many cards I added so far
		[SerializeField] private float gapBetweenCards = 60f;
		[SerializeField] private float animationDuration = 0;

		private void Start()
		{
			howManyAdded = 0.0f;
		}

		public IEnumerator InstantiateCards(int cardsInHand, DeckAsset deckAsset)
		{
			for (int i = 0; i < cardsInHand; i++)
			{
				GameObject cardObject = Instantiate(baseCard, cardPanel);
				Card card = cardObject.GetComponent<Card>();
				card.Initialize(deckAsset.cards[i]);
				items.Add(cardObject);
				yield return new WaitForSeconds(0.2f);
			}


			//StartCoroutine(FitCards());
		}

		private IEnumerator FitCards()
		{
			while (items.Count > 0)
			{
				GameObject img = items[0];

				Transform imgTransform = img.transform;
				imgTransform.position = startLocation.position; //relocating my card to the Start Position
				Vector3 newPos = imgTransform.position + new Vector3((howManyAdded * gapBetweenCards), 0, 0);
				img.transform.DOMove(newPos, animationDuration);
				yield return new WaitForSeconds(0);
				img.transform.SetParent(cardPanel); //Setting card parent to be the Hand Panel

				items.RemoveAt(0);
				howManyAdded++;
			}
		}
	}
}
