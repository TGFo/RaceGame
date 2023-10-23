using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    public bool inWave = false;
    public bool isAppropriateWave = false;
    public Animator animator;
    public IdleState idleState;
    public WaveState waveState;
    public CheerState cheerState;
    [SerializeField] private ISpectatorStates spectatorState;
    void Start()
    {
        Debug.Log("testinging");
        spectatorState = idleState;
        nextState();
    }
    private void Update()
    {
        //StartCoroutine(randomDelay());
    }
    public void nextState()
    {
        spectatorState = spectatorState.Action(this);
    }
    IEnumerator randomDelay()
    {
        float rand = Random.Range(0.0f, 1f);
        yield return rand;
        nextState();
    }
    public void stateChange()
    {
        StartCoroutine(randomDelay());
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
