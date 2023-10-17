using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons = new List<Weapon>(); 
    private Vector2 fireDirection = Vector2.right;

    private void TryFireWeapons()
    {
        for (int i = 0; i < weapons.Count; i++) 
        {
            if (weapons[i].CanFireWeapon())
                weapons[i].FireWeapon(fireDirection); 
        }
    }

    private void Update()
    {
        TryFireWeapons(); 
    }
}
