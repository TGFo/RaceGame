using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge <T>
{
    public GraphNode<T> nodeA { get; set; }
    public GraphNode<T> nodeB { get; set; }
    public Edge(GraphNode<T> nodeA, GraphNode<T> nodeB = null)
    {
        this.nodeA = nodeA;
        this.nodeB = nodeB;
        nodeA.ConnectEdge(this);
        if (nodeB != null)
        {
            nodeB.ConnectEdge(this);
        }
    }
}
