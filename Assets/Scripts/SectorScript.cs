using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorScript : MonoBehaviour
{
    public List<SectorScript> previousSector;
    public List<SectorScript> nextSector;
    public List<AdvancedWaypoint> waypoints;

    private void Awake()
    {
        waypoints.AddRange(GetComponentsInChildren<AdvancedWaypoint>());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
