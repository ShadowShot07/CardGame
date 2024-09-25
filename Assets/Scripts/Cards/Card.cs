using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dakard.Cards
{
   public class Card : MonoBehaviour
   {
      private static Dictionary<string, int> cardValues = new Dictionary<string, int>();

      [Header("Card visual properties")] [SerializeField]
      private Image image = null;

      [SerializeField] private TextMeshProUGUI cardName = null;
      [SerializeField] private TextMeshProUGUI descriptionText = null;
      [SerializeField] private TextMeshProUGUI manaCostText = null;
      [SerializeField] private TextMeshProUGUI damageText = null;
      [SerializeField] private TextMeshProUGUI healthText = null;
      [SerializeField] private TextMeshProUGUI levelText = null;

      [Header("UI properties")] 
      [SerializeField] private Button button = null;

      [SerializeField] private GameObject container = null;
      private EventTrigger _eventTrigger;
      private LayoutElement _layoutElement;

      private CardState _state; //Network

      private bool _followingCursor;

      public void Initialize(CardAsset cardAsset)
      {
         image.sprite = cardAsset.characterImage;
         descriptionText.text = cardAsset.description;
         manaCostText.text = cardAsset.manaCost.ToString();
         cardName.text = cardAsset.cardName;
         damageText.text = cardAsset.damage.ToString();
         healthText.text = cardAsset.health.ToString();
         _followingCursor = false;
         button.onClick.AddListener(OnCardInteraction);
         
         _layoutElement = GetComponent<LayoutElement>();
         _eventTrigger = GetComponent<EventTrigger>();
         
         SetState(CardState.OnHand);
         SetupEventTrigger(EventTriggerType.PointerEnter, OnCardPointerEnter);
         SetupEventTrigger(EventTriggerType.PointerExit, OnCardPointerExit);
      }

      private void SetupEventTrigger(EventTriggerType type, UnityAction<PointerEventData> action)
      {
         EventTrigger.Entry entry = new EventTrigger.Entry
         {
            eventID = type
         };
         entry.callback.AddListener((data) => { action((PointerEventData)data); });
         _eventTrigger.triggers.Add(entry);
      }

      private void Update()
      {
         if (_followingCursor)
         {
            transform.position = Input.mousePosition;
         }
      }

      private void OnCardInteraction()
      {
         switch (GetState())
         {
            case CardState.OnHand:
               SetIgnoreLayout(true);
               _followingCursor = true;
               SetState(CardState.Selected);
               container.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.2f);
               DeckEventSystem.Instance.OnSelectedCard?.Invoke(this);
               button.gameObject.SetActive(false);
               break;
         }
      } //Network

      private void OnCardPointerEnter(PointerEventData data)
      {
         switch (GetState())
         {
            case CardState.OnHand:
               container.transform.DOScale(new Vector3(2, 2, 2), 0.2f);
               break;
         }
      } //Network

      private void OnCardPointerExit(PointerEventData data)
      {
         switch (GetState())
         {
            case CardState.OnHand:
               container.transform.DOScale(new Vector3(1, 1, 1), 0.2f);
               break;
         }
      } //Network

      public void SetIgnoreLayout(bool ignoreLayout)
      {
         _layoutElement.ignoreLayout = ignoreLayout;
      }

      public void SetState(CardState state)
      {
         _state = state;

         if (state == CardState.OnBoard) // Make on state change and do this there 
         {
            _followingCursor = false;
         }
      }

      private CardState GetState()
      {
         return _state;
      }
   }

   public enum CardState
   {
      None,
      Stored,
      OnHand,
      Selected,
      OnBoard
   }
}
