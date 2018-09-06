using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : MonoBehaviour {


    public Rigidbody rb;

    public AnimationCurve liftCoefficientCurve;
    public float wingArea = 1.0f;
    public float wingAspectRatio = 1.0f;
    public Vector3 wind = Vector3.zero;
    public float rotationAngle = 20.0f;

    private Vector3 initialRotation;
    private Vector3 velocity;
    private Vector3 lastPosition;
    private float lastLift = 0;

    private Vector3 localVelocity;
    public Vector3 LocalVelocity
    {
        get { return localVelocity; }
    }

    private Vector3 chordAirVelocity;
    public Vector3 ChordAirVelocity
    {
        get { return chordAirVelocity; }
    }

    private float angleOfAttack;
    public float AngleOfAttack
    {
        get { return angleOfAttack; }
    }

    private Vector3 liftForce;

    private void Start()
    {
        lastPosition = transform.position;
        initialRotation = transform.localRotation.eulerAngles;
    }

    public Vector3 CalculateLiftForce ()
    {
        Vector3 velocity = (transform.position - lastPosition + wind) / Time.deltaTime;
        lastPosition = transform.position;

        //velocity = rb.GetPointVelocity(transform.position);

        localVelocity = transform.InverseTransformDirection(velocity);
        chordAirVelocity = new Vector3(0, localVelocity.y, localVelocity.z);
        angleOfAttack = Vector3.SignedAngle(Vector3.forward, chordAirVelocity, Vector3.right);

        float cl = liftCoefficientCurve.Evaluate(angleOfAttack);
        float lift = 0.5f * localVelocity.sqrMagnitude * wingArea * cl;



        //Induced drag coefficient
        float dci = (cl * cl) / (Mathf.PI * wingAspectRatio);

        //Vector3 liftDirection = Vector3.Cross(velocity, transform.right).normalized;
        Vector3 liftDirection = transform.up;
        liftForce = lift * liftDirection;

        Debug.DrawRay(transform.position, liftForce * 0.1f, Color.blue);
        Debug.DrawRay(transform.position, velocity * 0.1f, Color.cyan);

        return liftForce;
    }

    public void RotateWing (float input)
    {
        //TODO: Change this to use quaternions entirely
        //Temporally using Y axis for rotation because of gimbal lock issues.
        Vector3 rotation = new Vector3(0, input * rotationAngle, 0);
        transform.localRotation = Quaternion.Euler(initialRotation + rotation);
    }

    private void FixedUpdate()
    {
        
    }

}
