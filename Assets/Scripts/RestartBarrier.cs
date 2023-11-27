using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBarrier : MonoBehaviour
{
    public GameObject winLossPanel;

    private void OnCollisionEnter(Collision collision)
    {
        winLossPanel.SetActive(true);
    }
}
