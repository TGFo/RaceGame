using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] string testString = "test";
    int count = 0;
    [SerializeField] LinkedList<string> testList;
    void Start()
    {
        testList = new LinkedList<string>();
        for(int i = 0; i < 10; i++)
        {
            count = i;
            testList.AddLast(testString + count.ToString());
        }
        /*foreach(string testStrings in testList)
        {
            Debug.Log(testStrings);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
