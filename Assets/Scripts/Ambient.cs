using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient : MonoBehaviour {

	public static Ambient instance = null;

	public float airDensity = 1.0f;
	public Vector3 windVelocity;

	// Use this for initialization
	void Start () {
		if (instance == null) {

			instance = this;

		} else if (instance != this) {

			Destroy (gameObject);

		}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (transform.position, transform.position + windVelocity);
	}
}
