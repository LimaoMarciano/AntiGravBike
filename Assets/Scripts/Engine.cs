using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class Engine : MonoBehaviour {

    public float maxPower = 20.0f;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float input = Input.GetAxis("Vertical");

        if (input != 0)
        {
            rb.AddForce(maxPower * input * transform.forward);
        }
	}
}
