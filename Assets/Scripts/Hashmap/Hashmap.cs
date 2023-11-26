using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hashmap<T>
{
    Node<T>[] buckets;
    public Hashmap(int size)
    {
        buckets = new Node<T>[size];
    }
    public void Add(string key, T item) 
    {
        var valueNode = new Node<T>(item) { Key = key, Next = null};
        int position = GetBucketKey(key);
        Node<T> listNode = buckets[position];
        if (listNode == null)
        {
            buckets[position] = valueNode;
        }
        else
        {
            while (listNode.Next != null) listNode = listNode.Next;
            listNode.Next = valueNode;
        }

    }
    public T Get(string key)
    {
        var(_, node) = GetNodeByKey(key);
        if(node == null) throw new ArgumentOutOfRangeException(nameof(key), $"The Key '{key}' could not be found");
        return node.Value;
    }
    public string[] GetKeysFromValue(T value)
    {
        List<string> keys = new List<string>();
        Node<T> listNode = null;
        foreach(Node<T> bucket in buckets)
        {
            if(bucket.Value.Equals(value))
            {
                listNode = bucket;
                while(listNode.Next != null)
                {
                    keys.Add(listNode.Key);
                    listNode = listNode.Next;
                }
            }
        }
        return keys.ToArray();
    }
    public int GetBucketKey(string key)
    {
        return Mathf.Abs(key.GetHashCode());
    }
    private (Node<T> previous, Node<T> current) GetNodeByKey(string key)
    {
        int position = GetBucketKey(key);
        Node<T> listNode = buckets[position];
        Node<T> previous = null;
        while (listNode != null)
        {
            if (listNode.Key == key) return (previous, listNode);
            previous = listNode;
            listNode = listNode.Next;
        }
        return (null, null);
    }
    //code adapted from
    /*C# Data Structures and Algorithms: Implementing a Hash Table | packtpub.com. 2019. YouTube video, added by Packt. [Online]. Available at: https://www.youtube.com/watch?v=iKDhgVoXVTk [Accessed 22 November 2023].*/
}
