using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antigrav : MonoBehaviour {

    public PIDController altitudePID;
    public float lenght = 1.0f;
    public float maxForce = 10.0f;
    public float targetDistance = 5.0f;
    public Renderer meshRenderer;

    public Rigidbody rb;
    private Material mat;
    public Color pulseColor = Color.yellow;

	// Use this for initialization
	void Start () {
        mat = meshRenderer.materials[1];
	}

    // Update is called once per frame
    void FixedUpdate () { 

        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out hit, lenght))
        {
            float error = targetDistance - hit.distance;
            float force = maxForce * altitudePID.Update(error);

            float emission = altitudePID.Update(error);
            Color finalColor = pulseColor * Mathf.LinearToGammaSpace(emission);
            mat.SetColor("_EmissionColor", finalColor);

            rb.AddForceAtPosition(force * transform.up, transform.position);
        }

        Debug.DrawRay(transform.position, transform.TransformDirection (-transform.up) * lenght, Color.red);
    }

}
