using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : PlayerMovement
{
    [SerializeField] private Transform target;
    [SerializeField] private float stoppingDistance = .25f;
    [SerializeField] private float steeringForce = 10f; 
    private Vector3 targetDirection; 
    protected override void MovementUpdate()
    {
        targetDirection = (target.position - transform.position);
        if(targetDirection.sqrMagnitude < stoppingDistance * stoppingDistance) 
        {
            MovementDirection = Vector2.zero;
            return; 
        }
        MovementDirection = Vector2.MoveTowards(movementDirection, targetDirection, steeringForce * Time.deltaTime);
        base.MovementUpdate();
    }

}
