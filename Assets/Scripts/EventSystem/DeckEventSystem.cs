using System;
using Dakard.Cards;

public class DeckEventSystem
{
    public static DeckEventSystem Instance = new();

    public Action<Card> OnSelectedCard;
    public Action<BoardManager> PlaceCard;
}
