using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navtest : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public float agentSpeed = 1.0f;
    void Start()
    {
        agent.speed = agentSpeed;
        agent.acceleration = 3;
    }
    private void Update()
    {
        agent.destination = target.position;
    }
}
