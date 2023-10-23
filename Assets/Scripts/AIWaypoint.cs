using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaypoint : MonoBehaviour
{
    public Transform waypointTransform;
    public Vector3 nextWaypoint;
    public Node<Vector3> currentWaypoint;
    public WaypointManager waypointManager;
    public AIRacer racer;
    private void Start()
    {
        waypointManager = FindAnyObjectByType<WaypointManager>();
        currentWaypoint = waypointManager.waypointsLinked.Find(waypointTransform.position);
        Debug.Log(waypointManager.gameObject.name);
        nextWaypoint = currentWaypoint.Next.Value;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AIRacer")) 
        {
            racer = other.GetComponent<AIRacer>();
            racer.MoveTo(nextWaypoint);
        }
        if(other.CompareTag("Player") || other.CompareTag("AIRacer"))
        {
            if (currentWaypoint != waypointManager.waypointsLinked.First)
            {
                other.GetComponent<PlayerPassedPoints>().passedPoints++;
            }
            else
            {
                other.GetComponent<PlayerPassedPoints>().passedPoints = 1;
                other.GetComponent<PlayerPassedPoints>().currentLap++;
            }
        }
    }
}
