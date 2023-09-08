using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    Rigidbody carRigidbody;
    public MoveInput movement;
    public Vector3 moveVector;
    Vector3 turnVect;
    public float speedMult = 10;
    Transform tireTransform;
    public bool isFrontTire = true;
    private void Start()
    {
        tireTransform = GetComponent<Transform>();
        movement = GetComponentInParent<MoveInput>();
        carRigidbody = GetComponentInParent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        moveVector = GetInput().z * transform.forward;
        carRigidbody.AddForceAtPosition(moveVector * speedMult, tireTransform.position, ForceMode.Acceleration);
        if(isFrontTire)
        {
            carRigidbody.AddRelativeTorque(turnVect, ForceMode.Acceleration);
        }
    }
    private Vector3 GetInput()
    {
        turnVect = new Vector3(0, movement.inputMove.x);
        return new Vector3(0, 0, movement.inputMove.y);
    }
}
