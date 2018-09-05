using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour {

    public Bike bike;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bike.rudderInput = -Input.GetAxis("Horizontal");
        bike.engineInput = Input.GetAxis("Vertical");
	}

}
