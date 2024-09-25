using System.Collections.Generic;
using KS.Reactor;

namespace Map
{
    public class Node
    {
        public NodePoint NodePoint;
        public List<NodePoint> Incoming = new List<NodePoint>();
        public List<NodePoint> Outgoing = new List<NodePoint>();
        public NodeType NodeType;
        public string Name;
        public ksVector2 Position;

        public Node(NodeType nodeType, string name, NodePoint nodePoint)
        {
            NodeType = nodeType;
            Name = name;
            NodePoint = nodePoint;
        }
        public void AddIncoming(NodePoint nodePoint)
        {
            if (EqualNode(Incoming, nodePoint)) return;

            Incoming.Add(nodePoint);
        }

        public void AddOutgoing(NodePoint nodePoint)
        {
            if (EqualNode(Outgoing, nodePoint)) return;

            Outgoing.Add(nodePoint);
        }

        public void RemoveIncoming(NodePoint nodePoint)
        {
            RemoveElements(Incoming, nodePoint);
        }

        public void RemoveOutgoing(NodePoint nodePoint)
        {
            RemoveElements(Outgoing, nodePoint);
        }

        public bool NoConnections()
        {
            return Incoming.Count == 0 && Outgoing.Count == 0;
        }

        private bool EqualNode(List<NodePoint> list, NodePoint nodePoint)
        {
            foreach (var e in list)
            {
                if (e.Equals(nodePoint)) return true;
            }

            return false;
        }

        private void RemoveElements(List<NodePoint> list, NodePoint nodePoint)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].Equals(nodePoint)) list.RemoveAt(i);
            }
        }
    }
}