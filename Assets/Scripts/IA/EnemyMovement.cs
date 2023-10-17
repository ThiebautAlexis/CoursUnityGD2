using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : PlayerMovement
{
    [SerializeField] protected Transform target; 
   
    protected override void Update()
    {
        Vector3 _temp = Vector3.MoveTowards(MovementDirection, (target.position - transform.position), Time.deltaTime);
        if (_temp.magnitude > 1f) _temp.Normalize();
        MovementDirection = _temp;
        base.Update();    }
}
