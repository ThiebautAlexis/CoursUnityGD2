using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    protected Vector2 movementDirection = Vector2.zero;
    private float speed = 0f;
    private float accelerationTime = 0f;
    private bool canAccelerate = false; 
    [SerializeField] private PlayerMovementSettings settings;
    public Vector2 MovementDirection
    {
        get { return movementDirection; }
        set 
        {
            if (value.magnitude > 1.0f) value.Normalize();
            canAccelerate = value.magnitude > .0f;
            if (!canAccelerate) accelerationTime = 0; 
            movementDirection = value; 
        }
    }

    private void Update()
    {
        MovementUpdate();
    }

    protected virtual void MovementUpdate()
    {
        if (canAccelerate)
            accelerationTime += Time.deltaTime;
        speed = settings.CalculateSpeed(accelerationTime);

        transform.position += (Vector3)movementDirection * Time.deltaTime * speed;

    }
}
