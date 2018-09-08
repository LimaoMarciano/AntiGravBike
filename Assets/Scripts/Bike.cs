using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour {

    public Rigidbody rb;
    public Transform centerOfMass;

    public Engine engine;
    public Wing[] wings;
    public Wing[] rudders;

    public float rudderInput = 0;
    public float engineInput = 0;

    private DirectionalDrag directionalDrag;

	// Use this for initialization
	void Start () {
        rb.centerOfMass = transform.InverseTransformPoint(centerOfMass.position);
        directionalDrag = GetComponent<DirectionalDrag>();

        if (directionalDrag == null)
        {
            Debug.LogWarning("Directional drag component missing. Will use Rigidbody drag.");
        }
        else
        {
            rb.drag = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < rudders.Length; i++)
        {
            rudders[i].RotateWing(rudderInput);
        }

        engine.input = engineInput;
    }

    void FixedUpdate()
    {

        if (directionalDrag)
        {
            Vector3 dragForce = directionalDrag.CalculateDrag(rb.velocity);
            rb.AddForce(dragForce);
        }

        CalculateWingsLift(wings);
        CalculateWingsLift(rudders);
    }

    void CalculateWingsLift (Wing[] wings)
    {
        for (int i = 0; i < wings.Length; i++)
        {
            Vector3 force = wings[i].CalculateLiftForce(rb.GetPointVelocity(wings[i].transform.position));
            rb.AddForceAtPosition(force, wings[i].transform.position);
        }
    }
}
