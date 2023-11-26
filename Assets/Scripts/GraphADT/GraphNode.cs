using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode<T>
{
    public T Value { get; set; }
    public int numEdges;
    public List<Edge<T>> edges { get; set; }
    public GraphNode(T value)
    {
        this.Value = value;
        edges = new List<Edge<T>>();
    }
    public void ConnectEdge(Edge<T> edge)
    {
        this.edges.Add(edge);
        numEdges = edges.Count;
    }
}
