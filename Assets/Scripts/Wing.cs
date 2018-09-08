using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : MonoBehaviour {


    public Rigidbody rb;
    public WingProfile wingProfile;
    public Vector3 wind = Vector3.zero;
    public bool isDebugRayAllowed = false;

    private Vector3 initialRotation;
    private float sqrWingSpan;

    private float angleOfAttack;
    private Vector3 liftForce;
    private Vector3 inducedDragForce;
    private Vector3 resultantForce;

    //Public getters
    public float AngleOfAttack
    {
        get { return angleOfAttack; }
    }

    public Vector3 LiftForce
    {
        get { return liftForce; }
    }

    public Vector3 InducedDragForce
    {
        get { return inducedDragForce; }
    }

    public Vector3 ResultantForce
    {
        get { return resultantForce; }
    }

    private void Start()
    {
        initialRotation = transform.localRotation.eulerAngles;
        sqrWingSpan = (wingProfile.WingSpan * wingProfile.WingSpan) * Mathf.PI;
    }

    public Vector3 CalculateLiftForce (Vector3 airVelocity)
    {
        //Calculates wind direction and angle relative to the wing
        Vector3 localVelocity = transform.InverseTransformDirection(airVelocity);
        Vector3 chordAirVelocity = new Vector3(0, localVelocity.y, localVelocity.z);
        angleOfAttack = Vector3.SignedAngle(Vector3.forward, chordAirVelocity, Vector3.right);

        //Calculates lift force
        float cl = wingProfile.GetLiftCoefficient(angleOfAttack);
        float lift = 0.5f * localVelocity.sqrMagnitude * wingProfile.WingArea * cl;
        Vector3 liftDirection = Vector3.Cross(airVelocity, transform.right).normalized;
        liftForce = lift * liftDirection;
        
        //Induced drag calculation
        if (localVelocity.z != 0)
        {
            float dynamicPressure = (localVelocity.z * localVelocity.z) * 0.5f;
            float inducedDrag = (lift * lift) / (dynamicPressure * sqrWingSpan);
            inducedDragForce = inducedDrag * -airVelocity.normalized;
        }

        resultantForce = liftForce + inducedDragForce;
        return resultantForce;

    }

#if UNITY_EDITOR
    void LateUpdate()
    {
        if (isDebugRayAllowed)
        {
            Debug.DrawRay(transform.position, liftForce * 0.1f, Color.cyan);
            Debug.DrawRay(transform.position, inducedDragForce * 0.1f, Color.red);
            Debug.DrawRay(transform.position, resultantForce * 0.1f, Color.blue);
        }
    }
#endif

    public void RotateWing (float input)
    {
        //TODO: Change this to use quaternions entirely
        //Temporally using Y axis for rotation because of gimbal lock issues.
        Vector3 rotation = new Vector3(0, input * wingProfile.RotationAngle, 0);
        transform.localRotation = Quaternion.Euler(initialRotation + rotation);
    }

    

}
