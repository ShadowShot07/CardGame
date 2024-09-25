using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Dakard.Cards;

public class BoardManager : MonoBehaviour
{
    private EventTrigger _eventTrigger;
    [SerializeField] private Transform cardContainer = null;
    
    private void Start()
    {
        _eventTrigger = GetComponent<EventTrigger>();
        SetupEventTrigger(EventTriggerType.PointerUp, OnPointerUp);
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

    private void OnPointerUp(PointerEventData data)
    {
        //Send request to local client
        DeckEventSystem.Instance.PlaceCard?.Invoke(this);
    }

    public void PlaceCard(Card card)
    {
        card.transform.SetParent(cardContainer);
        card.SetState(CardState.OnBoard);
        card.SetIgnoreLayout(false);
    }
}
