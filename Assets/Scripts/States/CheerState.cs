using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheerState : MonoBehaviour, ISpectatorStates
{
    ISpectatorStates state;
    public ISpectatorStates Action(Spectator spectator)
    {
        ISpectatorStates nextState = this;
        spectator.animator.SetTrigger("TRCheer");
        int nextAction = Random.Range(0, 3);
        switch (nextAction)
        {
            case 0:
                if (spectator.isAppropriateWave)
                {
                    nextState = spectator.waveState;
                    StartCoroutine(DelayNextState(nextState));
                }
                break;
            case 1:
                nextState = spectator.cheerState;
                StartCoroutine(DelayNextState(nextState));
                break;
            default:
                nextState = spectator.idleState;
                StartCoroutine(DelayNextState(nextState));
                break;
        }
        return nextState;
    }
    private IEnumerator DelayNextState(ISpectatorStates spectatorStates)
    {
        float randomTime = Random.Range(0.0f, 2.0f);
        yield return randomTime;
        state = spectatorStates;
    }
}
