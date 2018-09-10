using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    public float maxPower = 20.0f;

    public Rigidbody rb;
    public float input = 0;

	// Use this for initialization
	void Start () {
        //rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (input != 0)
        {
            rb.AddForceAtPosition (maxPower * input * transform.forward, transform.position);
        }
	}
}
