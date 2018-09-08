using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalDrag : MonoBehaviour {

    public float lateralDrag = 10f;
    public float frontalDrag = 1f;
    public float upwardDrag = 10f;
    public bool isDebugRayAllowed = false;

    private Vector3 dragForce;
    public Vector3 DragForce
    {
        get { return dragForce; }
    }

    public Vector3 CalculateDrag (Vector3 airVelocity)
    {
        Vector3 localVelocity = transform.InverseTransformDirection(airVelocity);
        float lateralForce = localVelocity.x * localVelocity.x * lateralDrag * Mathf.Sign(localVelocity.x);
        float frontalForce = localVelocity.z * localVelocity.z * frontalDrag * Mathf.Sign(localVelocity.z);
        float upwardForce = localVelocity.y * localVelocity.y * upwardDrag * Mathf.Sign(localVelocity.y);

        Vector3 localDragForce = new Vector3(lateralForce, upwardForce, frontalForce);

        dragForce = transform.TransformDirection(-localDragForce);

        return dragForce;
    }

#if UNITY_EDITOR
    void LateUpdate()
    {
        if (isDebugRayAllowed)
        {
            Debug.DrawRay(transform.position, dragForce * 0.01f, Color.yellow);
        }
    }
#endif
}
