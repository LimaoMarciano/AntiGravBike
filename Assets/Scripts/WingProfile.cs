using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WingProfile", menuName = "Wing Profile", order = 51)]
public class WingProfile : ScriptableObject {

    [SerializeField]
    private float wingArea = 1.0f;

    [SerializeField]
    private float wingSpan = 1.0f;

    [SerializeField]
    private float rotationAngle = 20.0f;

    [SerializeField]
    private AnimationCurve liftCoefficientCurve;

    //Public getters
    public float WingArea
    {
        get { return wingArea; }
    }

    public float WingSpan
    {
        get { return wingSpan; }
    }

    public float RotationAngle
    {
        get { return rotationAngle; }
    }

    /// <summary>
    /// Returns the lift coefficient for the requested angle of attack
    /// </summary>
    /// <param name="angleOfAttack">Wing angle of attack in relation to wind flow</param>
    /// <returns>Return the lift coefficient for lift calculations</returns>
    public float GetLiftCoefficient (float angleOfAttack)
    {
        return liftCoefficientCurve.Evaluate(angleOfAttack);
    }

}
