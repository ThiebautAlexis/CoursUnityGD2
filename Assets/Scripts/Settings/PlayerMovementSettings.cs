using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Movement Settings", menuName = "Player Settings/Movement Settings", order = 0)]
public class PlayerMovementSettings : ScriptableObject
{
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float accelerationDuration = 2f; 
    [SerializeField] private AnimationCurve accelerationCurve = new AnimationCurve();

    public float CalculateSpeed(float _time)
    {
        _time = (_time / accelerationDuration); 
        if (_time <= 1)
        {
            return accelerationCurve.Evaluate(_time) * maxSpeed;
        }

        return maxSpeed; 
    }
}
