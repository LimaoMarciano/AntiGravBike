using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rudder : MonoBehaviour {

    public Rigidbody rb;
    public float maxForce = 10.0f;
    public float maxSpeed = 20.0f;
    public bool isInversed = false;
    public float input = 0;

    void FixedUpdate()
    {

        float airSpeed = Vector3.Dot(rb.velocity, transform.up);
        float efficiency = airSpeed / maxSpeed;

        rb.AddForceAtPosition(efficiency * maxForce * input * transform.right, transform.position);

    }
}
