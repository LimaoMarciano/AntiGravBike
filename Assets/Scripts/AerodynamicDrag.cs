using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerodynamicDrag : MonoBehaviour {

    public Rigidbody rb;
    public Vector3 dragCoefficient;
    public Vector3 area;

    private Vector3 parasiticDrag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 localVelocity = transform.InverseTransformDirection(rb.GetPointVelocity(transform.position));
        Vector3 velocityPow2 = Vector3.Scale(localVelocity, localVelocity);
        Vector3 velocityAreaProduct = Vector3.Scale(velocityPow2, area);
        parasiticDrag = Vector3.Scale(velocityAreaProduct, dragCoefficient);

        rb.AddForceAtPosition(transform.TransformDirection(parasiticDrag), transform.position);
	}

    private void LateUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(parasiticDrag), Color.red);
    }
}
