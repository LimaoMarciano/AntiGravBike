using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour {

    public Engine engine;
    public Wing leftWing;
    public Wing rightWing;
    public Rudder rudder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        engine.input = Input.GetAxis("Vertical");
        leftWing.input = Input.GetAxis("Vertical2");
        rightWing.input = Input.GetAxis("Vertical2");
        rudder.input = Input.GetAxis("Horizontal");
	}

}
