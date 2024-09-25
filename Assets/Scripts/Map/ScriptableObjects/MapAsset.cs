using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    [CreateAssetMenu(menuName = "Dakard/Map")]
    public class MapAsset : ScriptableObject
    {
        public List<NodeAsset> NodeAsset;
        public IntMinMax PreBossNodes;
        public IntMinMax StartingNodes;
        public int GridWidth { get { return Mathf.Max(PreBossNodes.max, StartingNodes.max); } }
        public ListMapLayers Layers;

        public class ListMapLayers : List<Layers>
        {
        }
    }
}
