using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pickup is an object aimed at passing weapon functionality to player objects. Depending on
/// the specified weaponType, the Pickup will tell the player object what object it should now
/// use as it's weapon.
/// </summary>
public class Pickup : MonoBehaviour
{
    [SerializeField]
    public WeaponType weaponType;
    [SerializeField]
    private int healAmount = 10;

    // if the game object with the tag "Player" has triggered with another object call the HandlePlayerPickup method
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = col.gameObject;
            HandlePlayerPickup(player);
        }
    }

    // if the game object with the tag "Player" has collided with another object call the HandlePlayerPickup method
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = col.gameObject;
            HandlePlayerPickup(player);
        }
    }

    /// <summary>
    /// HandlePlayerPickup handles all of the actions after a player has been collided with.
    /// It grabs the IWeapon component from the player, transfers all information to a new IWeapon (based on the provided weaponType).
    /// </summary>
    /// <param name="player"></param>
    private void HandlePlayerPickup(GameObject player)
    {
        // get the playerInput from the player
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        // handle a case where the player doesnt have a PlayerInput
        if (playerInput == null) 
        {
            Debug.LogError("Player doesn't have a PlayerInput component.");
            return;
        } 
        else 
        {
            // if the triple shot powerup is 'picked up'
            if (CompareTag("Pickup"))
            {
                // tell the playerInput to SwapWeapon based on our weaponType
                playerInput.SwapWeapon(weaponType);
            }
            // if not the triple shot but if the healing power up is 'picked up'
            else if (CompareTag("Heal"))
            {
                // heal the player by the set healing amount
                player.GetComponent<IHealth>().Heal(healAmount);
            }
        }
    }
}

// types of weapons available,
// none was created so that the heal pickup did not have to have a weapon type option
public enum WeaponType { machineGun, tripleShot, none }
