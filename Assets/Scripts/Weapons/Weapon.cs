using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damages = 1;
    [SerializeField] private float range = 5f;
    [SerializeField] private float cooldown = 1;
    [SerializeField] private ParticleSystem projectiles = null; 

    /// <summary>
    /// Play the Particle System and reset the cooldown.
    /// </summary>
    /// <param name="_fireDirection"></param>
    public void FireWeapon()
    {
        currentCooldown = 0f; 
        // Set the projectile direction according to the fire direction
        projectiles.Play(); 
    }

    /// <summary>
    /// Check if the weapon can fire.
    /// </summary>
    private float currentCooldown = 0f; 
    public bool CanFireWeapon()
    {
        currentCooldown += Time.deltaTime;
        return currentCooldown >= cooldown;
    }

    /// <summary>
    /// Method called when the particles collide with something.
    /// According to the parameters in the collisions module of the Particle System
    /// (layer, 2d or 3d collisions, etc) and if the Send Collisions Messages is enabled
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        if(other.TryGetComponent(out Damageable _damageable))
        {
            _damageable.TakeDamages(damages); 
            //PlayerController.AddScore(100);
        }
    }
}
