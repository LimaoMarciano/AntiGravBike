using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour {

    public Rigidbody rb;

    public Engine engine;
    public Wing[] wings;
    public Wing[] rudders;

    public float rudderInput = 0;
    public float engineInput = 0;

	// Use this for initialization
	void Start () {
		
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

        for (int i = 0; i < wings.Length; i++)
        {
            Vector3 force = wings[i].CalculateLiftForce();
            rb.AddForceAtPosition(force, wings[i].transform.position);
        }

        for (int j = 0; j < rudders.Length; j++)
        {
            Vector3 force = rudders[j].CalculateLiftForce();
            rb.AddForceAtPosition(force, rudders[j].transform.position);
        }
    }
}
