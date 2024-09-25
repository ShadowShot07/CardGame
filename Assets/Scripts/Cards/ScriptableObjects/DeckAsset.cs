using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dakard/Deck")]
public class DeckAsset : ScriptableObject
{
    public List<CardAsset> cards;
    public DeckType deckType;
}

public enum DeckType
{
    None,
    Humanoid,
    Beast,
    Monster,
    Undead,
    Magic,
    Destiny,
    Weapon
}
