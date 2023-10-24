using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons = new List<Weapon>(); 
    private Vector2 fireDirection = Vector2.right;
    public Vector2 FireDirection
    {
        get { return fireDirection; }
        set 
        {
            if (value.magnitude == 0f) return; 
            fireDirection = value;
        }
    }

    private void TryFireWeapons()
    {
        for (int i = 0; i < weapons.Count; i++) 
        {
            weapons[i].transform.LookAt(transform.position + (Vector3)fireDirection);
            if (weapons[i].CanFireWeapon())
                weapons[i].FireWeapon(); 
        }
    }

    private void Update()
    {
        TryFireWeapons(); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, fireDirection);
    }
}
