using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AdvancedWaypoint : MonoBehaviour
{
    public AdvancedWaypointManager manager;
    public SectorScript currentSector;
    public List<GraphNode<Vector3>> nextPos;
    public List<GraphNode<Vector3>> prevPos;
    public Transform movetoPos;
    public GraphNode<Vector3> node;
    public AIRacer racer;
    public bool first = false;
    public bool last = false;
    public int nextIndex = 0;
    private void OnEnable()
    {
        nextPos= new List<GraphNode<Vector3>>();
        prevPos= new List<GraphNode<Vector3>>();
        currentSector = GetComponentInParent<SectorScript>();
        node = new GraphNode<Vector3>(movetoPos.position);
        manager = FindAnyObjectByType<AdvancedWaypointManager>();
        manager.graph.AddNode(node);
    }
    private void Start()
    {
        if(first == true)
        {
            foreach(SectorScript previoussector in currentSector.previousSector)
            {
                Debug.Log(previoussector);
                prevPos.Add(previoussector.waypoints.Last().node);
                nextPos.Add(currentSector.waypoints[currentSector.waypoints.IndexOf(this) + 1].node);
            }
        }
        if(last == true)
        {
            foreach (SectorScript nextSector in currentSector.nextSector)
            {
                nextPos.Add(nextSector.waypoints.First().node);
            }
        }
        if(first == false && last == false)
        {
            nextPos.Add(currentSector.waypoints[currentSector.waypoints.IndexOf(this) + 1].node);
            prevPos.Add(currentSector.waypoints[currentSector.waypoints.IndexOf(this) - 1].node);
        }
        foreach (GraphNode<Vector3> prev in prevPos)
        {
            manager.graph.AddEdge(prev, node);
        }
        foreach(GraphNode<Vector3> next in nextPos)
        {
            manager.graph.AddEdge(node, next);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AIRacer"))
        {
            racer = other.GetComponent<AIRacer>();
            nextIndex = Random.Range(0, nextPos.Count);
            racer.MoveTo(nextPos[nextIndex].Value);
        }
        if (other.CompareTag("Player") || other.CompareTag("AIRacer"))
        {
            if (node != manager.firstWaypoint.node)
            {
                other.GetComponent<PlayerPassedPoints>().passedPoints++;
            }
            else
            {
                other.GetComponent<PlayerPassedPoints>().passedPoints = 1;
                other.GetComponent<PlayerPassedPoints>().currentLap++;
            }
            SFXManager.instance.PlaySound("cheer2");
        }
    }
}
