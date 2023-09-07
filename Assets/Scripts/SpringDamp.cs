using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringDamp : MonoBehaviour
{
    public Transform wheelPos;
    //The transform representing the specific wheel

    public Rigidbody carRigidBody;
    //The main rigidbody of the car

    [SerializeField] float springStrength = 50;
    //The strength of the suspension spring

    [SerializeField] float springRestLength = 10;
    //the length at which the suspension string is at rest / not exerting a force in any direction

    [SerializeField] float springDamper = 15;
    //The damping value of the vehicle's suspension

    float offset = 0;
    //The signed value distance of the springs end from its rest position

    float suspensionForce = 0;
    //The force exerted by the suspension on the car's rigidbody

    float springVelocityMagnitude = 0;
    //The magnitude of the velocity of the spring's end at a given moment

    Vector3 springVelocity = Vector3.zero;
    //The velocity of the spring's end at a given moment

    Vector3 springForceDir;
    //Direction of the force applied by the spring

    RaycastHit hit;

    private void OnEnable()
    {
        wheelPos = GetComponent<Transform>();
        carRigidBody = GetComponentInParent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        bool hitGround = Physics.Raycast(wheelPos.position, -transform.up, out hit, springRestLength);
        if (hitGround)
        {
            offset = springRestLength - hit.distance;
            //offset calculated from raycast distance

            springForceDir = wheelPos.up;

            springVelocity = carRigidBody.GetPointVelocity(wheelPos.position);
            //Velocity of the rigidbody at the position of the "wheel"

            springVelocityMagnitude = Vector3.Dot(springVelocity, springForceDir);

            suspensionForce = (offset * springStrength) - (springVelocityMagnitude * springDamper);

            carRigidBody.AddForceAtPosition(springForceDir * suspensionForce, wheelPos.position);
        }
    }
}
