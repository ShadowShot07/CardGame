using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Dakard/Card/New Card")]
public class CardAsset : ScriptableObject
{
  public int manaCost;
  [FormerlySerializedAs("life")] public int health;
  public int damage;
  public string description;
  public string cardName;
  public Sprite characterImage;
  public CardType cardType;
}

public enum CardType
{
  None,
  Creature,
}