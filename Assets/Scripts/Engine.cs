using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class Engine : MonoBehaviour {

    public float maxPower = 20.0f;

    private Rigidbody rb;
    public float input = 0;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (input != 0)
        {
            rb.AddForce(maxPower * input * transform.forward);
        }
	}
}
