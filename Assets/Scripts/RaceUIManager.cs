using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RaceUIManager : MonoBehaviour
{
    WaypointManager waypointManager;
    AdvancedWaypointManager advancedWaypointManager;
    GameObject player;
    [SerializeField] TMP_Text positionText;
    [SerializeField] TMP_Text lapText;
    public int currentLap = 0;
    [SerializeField] private int maxLaps = 3;
    public bool beginner = true;
    void Start()
    {
        if(beginner)waypointManager = FindAnyObjectByType<WaypointManager>();
        else advancedWaypointManager= FindAnyObjectByType<AdvancedWaypointManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentLap = player.GetComponent<PlayerPassedPoints>().currentLap;
        lapText.text = currentLap.ToString() + " / " + maxLaps.ToString();
        if(beginner)positionText.text = (Array.IndexOf(waypointManager.SortPositions(), player) + 1).ToString() + " / " + waypointManager.racersObjects.Length;
        else positionText.text = (Array.IndexOf(advancedWaypointManager.SortPositions(), player) + 1).ToString() + " / " + advancedWaypointManager.racersObjects.Length;
    }
}
