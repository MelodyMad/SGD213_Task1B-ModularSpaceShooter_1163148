using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DamageOnCollision handles the damage that is inflicted by an object on an object when collided with
/// </summary>
public class DamageOnCollision : DetectCollisionBase
{
    // amount of damage that is dealt
    [SerializeField]
    private int damageToDeal;

    protected override void ProcessCollision(GameObject other)
    {
        base.ProcessCollision(other);
        // if IHealth if attached then the game object will take damage based on the amount that is dealt
        if (other.GetComponent<IHealth>() != null) 
        {
            other.GetComponent<IHealth>().TakeDamage(damageToDeal);
        }
        else 
        {
            // if IHealth is not attached then this is explicitly stated in the consol
            Debug.Log(other.name + " does not have an IHealth component");
        }

        // after the damage is dealt to an object, the object that inflicted the damage is destroyed
        Destroy(gameObject);
    }
}
