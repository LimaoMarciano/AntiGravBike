using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalComponent : MonoBehaviour
{
    public float rotationRange = 20.0f;
    public bool isReversed = false;
    public Vector3 rotationAxis;

    private Quaternion initialRotation;

    // Use this for initialization
    void Start()
    {
        initialRotation = transform.localRotation;
    }

    public void Rotate(float input)
    {
        if (isReversed)
        {
            input *= -1;
        }

        float angle = input * rotationRange;
        transform.localRotation = initialRotation * Quaternion.Euler(angle * rotationAxis.x, angle * rotationAxis.y, angle * rotationAxis.z);
    }
}
