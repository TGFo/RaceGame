using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node <T>
{
    public Node<T> Next { get; set; }
    public T Value { get; set; }
    public string Key { get; set; }
    public Node(T value, Node<T> next = null)
    {
        this.Value = value;
        this.Next = next;
    }
}
