using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KS.Reactor;
using System.IO;

namespace Map
{
    public static class MapGenerator 
    {
        private static MapAsset config;
        private static readonly List<NodeType> randomNodes = new List<NodeType>();
        private static List<float> layerDistances;
        private static List<List<NodePoint>> nodePoints;
        private static readonly List<List<Node>> nodes = new List<List<Node>>();

        /*public static MapBase GetMap(MapAsset conf)
        {
            if (conf == null) { return null; }
            
            config = conf;
            nodes.Clear();


        }*/

        private static void LayerDistances()
        {
            layerDistances = new List<float>();
            foreach (var layer in config.Layers) { layerDistances.Add(layer.DistanceFromPreviousLayer.GetValue()); };
        }

        private static float DistanceToLayer(int layerIndex)
        {
            if (layerIndex < 0 || layerIndex > layerDistances.Count) return 0f;

            return layerDistances.Take(layerIndex +1).Sum();
        }

        private static void PlaceLayer (int layerIndex)
        {
            var layer = config.Layers[layerIndex];
            var nodesOnThisLayer = new List<Node>();

            var offset = layer.DistanceBetweenNodes * config.GridWidth / 2f;

            for (var i = 0; i < config.GridWidth; i++)
            {
                var nodeType = Random.Range(0f, 1f) < layer.RandomizeNodes ? GetRandomNode() : layer.NodeType;
                var blueprintName = config.NodeAsset.Where(b => b.nodeType == nodeType).ToList().Random().name;
                var node = new Node(nodeType, blueprintName, new NodePoint(i, layerIndex))
                {
                    Position = new ksVector2(-offset + i * layer.DistanceBetweenNodes, DistanceToLayer(layerIndex))
                };
                nodesOnThisLayer.Add(node);
            }
            nodes.Add(nodesOnThisLayer);
        }

        private static void RandomNodePosition()
        {
            for (var index = 0; index < nodes.Count; index++)
            {
                var list = nodes[index];
                var layer = config.Layers[index];
                var distanceToNextLayer = index + 1 >= layerDistances.Count ? 0f : layerDistances[index +1];
                var distanceToPreviousLayer = layerDistances[index];

                foreach (var node in list)
                {
                    var xR = Random.Range(-1f, 1f);
                    var yR = Random.Range(-1f, 1f);

                    var x = xR * layer.DistanceBetweenNodes / 2f;
                    var y = yR < 0 ? distanceToPreviousLayer * yR / 2f : distanceToNextLayer * yR / 2f;

                    node.Position += new ksVector2(x, y) * layer.RandomizePosition;
                }
            }
        }

        private static void SetUpConnections()
        {
            foreach (var point in nodePoints)
            {
                for (var i = 0; i < point.Count -1; i++)
                {
                    var node = GetNode(point[i]);
                    var nextNode = GetNode(point[i + 1]);
                    node.AddOutgoing(nextNode.NodePoint);
                    nextNode.AddIncoming(node.NodePoint);
                }
            }
        }

        private static NodeType GetRandomNode()
        {
            return randomNodes[Random.Range(0, randomNodes.Count)];
        }

        private static Node GetNode(NodePoint point)
        {
            if (point.y >= nodes.Count) return null;
            if (point.x >= nodes[point.y].Count) return null;

            return nodes[point.y][point.x];
        }
    }
}
