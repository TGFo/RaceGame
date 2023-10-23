using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LinkedList <T>
{

    public int Count { get; private set; }
    public Node<T> First { get; private set; }
    public Node<T> Last { get; private set; }
    public LinkedList() 
    {
        this.First = null;
        this.Last = null;
        this.Count = 0;
    }
    public void AddFirst(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if(Count == 0)
        {
            this.First = newNode;
            this.First.Next = this.First;
            this.Last = this.First;
        }else
        {
            newNode.Next = this.First;
            this.First = newNode;
            this.Last.Next = this.First;
        }
        this.Count++;
    }
    public void AddLast(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (Count == 0)
        {
            this.First = newNode;
            this.First.Next = this.First;
            this.Last = this.First;
        }
        else
        {
            newNode.Next = this.First;
            this.Last.Next = newNode;
            this.Last = newNode;
        }
        this.Count++;
    }
    public void AddAfter(T newValue, Node<T> existingNode)
    {
        Node<T> newNode = new Node<T>(newValue);
        if(this.Last == existingNode)
        {
            Last = newNode;
        }
        newNode.Next = existingNode.Next;
        existingNode.Next = newNode;
        this.Count++;
    }
    public Node<T> Find(T target)
    {
        Node<T> currentNode = First;
        while (currentNode != null && !currentNode.Value.Equals(target)) 
        {
            currentNode = currentNode.Next;
        }
        return currentNode;
    }
    //code adapted from
    /*How to create a LinkedList from scratch using C# and Visual Studio. 2021. YouTube video, added by Gen Grievous. [Online]. Available at: https://www.youtube.com/watch?v=8TGFk_zUS9A [Accessed 16 October 2023].*/
}
