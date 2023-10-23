using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RaceUIManager : MonoBehaviour
{
    WaypointManager waypointManager;
    GameObject player;
    [SerializeField] TMP_Text positionText;
    [SerializeField] TMP_Text lapText;
    public int currentLap = 0;
    [SerializeField] private int maxLaps = 3;
    void Start()
    {
        waypointManager = FindAnyObjectByType<WaypointManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentLap = player.GetComponent<PlayerPassedPoints>().currentLap;
        lapText.text = currentLap.ToString() + " / " + maxLaps.ToString();
        positionText.text = (Array.IndexOf(waypointManager.SortPositions(), player) + 1).ToString() + " / " + waypointManager.racersObjects.Length;
    }
}
