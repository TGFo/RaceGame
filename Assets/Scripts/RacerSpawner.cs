using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerSpawner : MonoBehaviour
{
    [SerializeField] AIRacerFactory racerFactory;
    [SerializeField] Transform[] startPositions;
    [SerializeField] GameObject startPositionParent;
    [SerializeField] GameObject defaultRacerPrefab;
    [SerializeField] bool beginner = true;
    public WaypointManager waypointManager;
    public AdvancedWaypointManager advancedManger;
    void Start()
    {
        //delays the instatiation of any airacers for a single frame so as to allow the linked list to be populated so it can be used to start movement on game start
        StartCoroutine(DelayedStart());
    }
    public void spawnRacer(int racerType, Transform startPos)
    {
        IRacer racerInstance =  racerFactory.CreateRacer(racerType);
        racerInstance.AddInstance(startPos.position);
        if(beginner == true) racerInstance.MoveTo(waypointManager.firstWaypoint);
        else racerInstance.MoveTo(advancedManger.firstWaypoint.node.Value);
    }
    IEnumerator DelayedStart()
    {
        yield return null;
        int randomInt = 0;
        startPositions = startPositionParent.GetComponentsInChildren<Transform>();
        Debug.Log("checkspawner");
        foreach (Transform startPosition in startPositions)
        {
            if(startPosition != startPositions[0])
            {
                Debug.Log("checkspawnerfor");
                randomInt = Random.Range(0, 3);
                spawnRacer(randomInt, startPosition);
            }
        }
    }
}
