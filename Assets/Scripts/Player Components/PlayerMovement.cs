using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 movementDirection = Vector2.zero;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float accelerationTime = 0f;
    [SerializeField] private bool canAccelerate = false; 
    [SerializeField] private PlayerMovementSettings settings;
    public Vector2 MovementDirection
    {
        get { return movementDirection; }
        set 
        {
            if (value.magnitude > 1.0f) return;
            canAccelerate = value.magnitude > .0f;
            if (!canAccelerate) accelerationTime = 0; 
            movementDirection = value; 
        }
    }

    private void Update()
    {
        if (canAccelerate)
            accelerationTime += Time.deltaTime; 
        speed = settings.CalculateSpeed(accelerationTime) ; 

        transform.position += (Vector3)MovementDirection * Time.deltaTime * speed; 
    }

    public void OnInputMovement(InputAction.CallbackContext _context)
    {
        MovementDirection = _context.ReadValue<Vector2>();
    }
}
