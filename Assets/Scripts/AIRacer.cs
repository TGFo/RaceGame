using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour, IRacer
{
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float acceleration;
    [SerializeField] NavMeshAgent racerAI;
    [SerializeField] protected GameObject appearence;
    [SerializeField] public string racerName;
    [SerializeField] protected GameObject racerInstance;
    public int passedCheckPoints = 0;
    public void Initialize(Vector3 startPos)
    {
        //appearence = (GameObject)Resources.Load("PlaceHolderprefab");
        //racerInstance = Instantiate(new GameObject(racerName));
        Debug.Log("checkInst");
        racerInstance = gameObject;
        Debug.Log("checkInst2");
        racerInstance.name = racerName;
        racerInstance.transform.position = startPos;
        racerAI = racerInstance.GetComponentInChildren<NavMeshAgent>();
        racerAI.speed = maxSpeed;
        racerAI.acceleration = acceleration;
        racerAI.enabled = false;
        racerAI.enabled = true;
        //navmeshagent couldn't recgonize the navmesh unless disabled then reenabled for some reason. Most likely a weird quirk of the factory pattern implemenation or a unity bug 
        Debug.Log("before appear");
        Instantiate(appearence, racerInstance.transform);
        Debug.Log("after");
        Debug.Log("initialized");
    }
    public void MoveTo(Vector3 position)
    {
        racerAI.destination = position;
    }
    public virtual void AddInstance(Vector3 startPos)
    {
    }
}
