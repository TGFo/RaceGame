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
    public bool isDriveWheel = true;
    RaycastHit hit;
    private void Start()
    {
        tireTransform = GetComponent<Transform>();
        movement = GetComponentInParent<MoveInput>();
        carRigidbody = GetComponentInParent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -tireTransform.up, out hit, GetComponent<SpringDamp>().GetSpringRestLength()))
        {
            moveVector = GetInput().z * transform.forward;
            if (isDriveWheel)
            {
                carRigidbody.AddForceAtPosition(moveVector * speedMult, tireTransform.position, ForceMode.Acceleration);
            }
            if (isFrontTire && transform.forward != Vector3.zero)
            {
                carRigidbody.AddRelativeTorque(turnVect, ForceMode.Acceleration);
            }
            //Debug.Log("velocity:" + carRigidbody.velocity);
        }
    }
    private Vector3 GetInput()
    {
        turnVect = new Vector3(0, movement.inputMove.x);
        return new Vector3(0, 0, movement.inputMove.y);
    }
}
