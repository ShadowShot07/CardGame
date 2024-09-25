using System.Collections.Generic;

namespace Map
{
    public class MapBase
    {
        public List<Node> Node;
        public List<NodePoint> NodePoint;
        public string BossNodeName;
        public string MapConfigName;

        public MapBase(string mapConfigName, string bossNodeName, List<Node> node, List<NodePoint> nodePoint)
        {
            MapConfigName = mapConfigName;
            BossNodeName = bossNodeName;
            Node = node;
            NodePoint = nodePoint;
        }

        public Node BossNode()
        {
            foreach (var n in Node)
            {
                if (n.NodeType == NodeType.BossRoom) return n;
            }
            return null;
        }

        public float DistanceLayers()
        {
            var bossNode = BossNode();
            Node FirstLayerNode = null;

            foreach (var n in Node)
            {
                if (n.NodePoint.y == 0)
                {
                    FirstLayerNode = n;
                    break;
                }
            }

            if (bossNode == null || FirstLayerNode == null)
            {
                return 0f;
            }

            return bossNode.Position.Y - FirstLayerNode.Position.Y;
        }

        public Node GetNode(NodePoint point)
        {
            foreach (var n in Node)
            {
                if (n.NodePoint.Equals(point)) return n;
            }
            return null;
        }
    }
}