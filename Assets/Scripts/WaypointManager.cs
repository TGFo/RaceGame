using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public GameObject WaypointParent;
    public AIWaypoint[] waypoints;
    public LinkedList<Vector3> waypointsLinked = new LinkedList<Vector3>();
    List<GameObject> racerObjectList = new List<GameObject>();
    public GameObject[] racersObjects;
    public Vector3 firstWaypoint;
    private void OnEnable()
    {
        waypoints = WaypointParent.GetComponentsInChildren<AIWaypoint>();
        foreach(AIWaypoint waypoint in waypoints)
        {
            waypointsLinked.AddLast(waypoint.waypointTransform.position);
        }
        firstWaypoint = waypointsLinked.First.Value;
        //waypointsLinked.AddFirst(waypointsLinked.Last.Value);
        Debug.Log(waypointsLinked.First);
    }
    private void Start()
    {
        StartCoroutine(DelayedPositions());
    }
    IEnumerator DelayedPositions()
    {
        yield return 0.1f;
        racerObjectList.AddRange(GameObject.FindGameObjectsWithTag("AIRacer"));
        racerObjectList.Add(GameObject.FindGameObjectWithTag("Player"));
        racersObjects = racerObjectList.ToArray();
    }
    public GameObject[] SortPositions()
    {
        int n = racersObjects.Length;
        for(int i = 0; i < n - 1; i++)
        {
            for(int j = 0; j < n - i - 1; j++) 
            {
                if (racersObjects[j].GetComponent<PlayerPassedPoints>().passedPoints < racersObjects[j + 1].GetComponent<PlayerPassedPoints>().passedPoints)
                {
                    (racersObjects[j + 1], racersObjects[j]) = (racersObjects[j], racersObjects[j + 1]);
                }
            }
        }
        return racersObjects;
    }
}
