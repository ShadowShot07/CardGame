using UnityEngine;

namespace Map
{
    public class Layers
    {
        public NodeType NodeType;
        public FloatMinMax DistanceFromPreviousLayer;
        public float DistanceBetweenNodes;
        [Range(0f, 1f)] public float RandomizePosition;
        [Range(0f, 1f)] public float RandomizeNodes;
    }
}