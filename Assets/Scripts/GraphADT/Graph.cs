using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph <T>
{
    public List<GraphNode<T>> graphNodes { get; set; }
    public List<Edge<T>> edges { get; private set; }

    public Graph()
    {
        graphNodes = new List<GraphNode<T>>();
        edges = new List<Edge<T>>();
    }
    public GraphNode<T> CreateNode(T value)
    {
        GraphNode<T> addedGraphNode= new GraphNode<T>(value);
        graphNodes.Add(addedGraphNode);
        return addedGraphNode;
    }
    public void AddEdge(GraphNode<T> nodeA, GraphNode<T> nodeB = null)
    {
        Edge<T> edge = new Edge<T>(nodeA, nodeB);
        edges.Add(edge);
    }
    public void AddAndConnected(T value, GraphNode<T> graphNode = null) 
    {
        if (graphNodes.Contains(FindNode(value)))
        {
            if (graphNode == null) return;
            AddEdge(graphNode, FindNode(value));
            return;
        }
        GraphNode<T> addedNode = CreateNode(value);
        if (graphNode == null) return;
        AddEdge(graphNode, FindNode(addedNode.Value));
    }
    public GraphNode<T> FindNode(T target)
    {
        GraphNode<T> targetNode = null;
        foreach(GraphNode<T> node in graphNodes)
        {
            if(node.Value.Equals(target)) 
            {
                targetNode = node;
                break;
            }
        }
        if (targetNode == null)
        {
            Debug.Log("Could not find target GraphNode with value of " + target.ToString() + "\n returned null");
            return targetNode;
        }
        int index = graphNodes.IndexOf(targetNode);
        return graphNodes[index];
    }
    public void AddNode(GraphNode<T> node)
    {
        graphNodes.Add(node);
    }
}
