using UnityEngine;

namespace Map
{
    [CreateAssetMenu(menuName = "Dakard/Node")]
    public class NodeAsset : ScriptableObject
    {
        public Sprite sprite;
        public NodeType nodeType;
    }
}

namespace Map
{
    public enum NodeType
    {
        NormalEnemyRoom,
        BossRoom,
        TreasureRoom,
        InnRoom,
        AlchemistRoom,
        TraderRoom,
        CatalystRoom,
        MutatorRoom,
        CardDealerRoom,
    }
}
