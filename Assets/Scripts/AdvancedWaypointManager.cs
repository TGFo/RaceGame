using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedWaypointManager : MonoBehaviour
{
    public Graph<Vector3> graph = new Graph<Vector3>();
    public List<Vector3> waypoints = new List<Vector3>();
    public AdvancedWaypoint firstWaypoint;
    List<GameObject> racerObjectList = new List<GameObject>();
    public GameObject[] racersObjects;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedPositions());
        SFXManager.instance.PlaySound("raceStartBoom");
    }

    // Update is called once per frame
    void Update()
    {
        
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
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
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
