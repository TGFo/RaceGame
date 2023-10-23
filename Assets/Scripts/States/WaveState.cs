using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveState : MonoBehaviour, ISpectatorStates
{
    ISpectatorStates state;
    float waveDuration = 0;
    public ISpectatorStates Action(Spectator spectator)
    {
        ISpectatorStates nextState = this;
        spectator.animator.SetTrigger("TRWave");
        spectator.isAppropriateWave = false;
        spectator.inWave = true;
        int nextAction = Random.Range(0, 2);
        switch (nextAction)
        {
            case 0:
                nextState = spectator.cheerState;
                StartCoroutine(DelayNextState(nextState, spectator));
                break;
            default:
                nextState = spectator.idleState;
                StartCoroutine(DelayNextState(nextState, spectator));
                break;
        }
        return nextState;
    }
    private IEnumerator DelayNextState(ISpectatorStates spectatorStates, Spectator spectator)
    {
        float timeUntilNext = waveDuration;
        yield return timeUntilNext;
        spectator.isAppropriateWave = true;
        spectator.inWave = false;
        state = spectatorStates;
    }
}
