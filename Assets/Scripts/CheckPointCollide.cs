using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollide : MonoBehaviour
{
    public bool pointTriggered = false;
    CheckPointManager checkPointManager;

    private void Start()
    {
        checkPointManager = FindObjectOfType<CheckPointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && pointTriggered == false)
        {
            checkPointManager.TriggerCheckpoint(gameObject);
        }
    }
}
