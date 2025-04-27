using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerInput handles all of the player specific input behaviour, and passes the input information to the appropriate scripts.
/// </summary>
public class PlayerInput : MonoBehaviour
{
    // local references
    private EngineBase movement;

    private WeaponBase weapon;
    public WeaponBase Weapon
    {
        get { return weapon; }
        set { weapon = value; }
    }

    // create a cooldown timer for when the pickup revents back to normal
    [SerializeField]
    private float powerupDuration = 5f;
    private float powerupTimer = 0f;
    
    void Start()
    {
        movement = GetComponent<EngineBase>();
        weapon = GetComponent<WeaponBase>();
    }

    void Update()
    {
        // read our horizontal input axis
        float horizontalInput = Input.GetAxis("Horizontal");
        // if movement input is not zero
        if (horizontalInput != 0.0f)
        {
            // ensure our playerMovementScript is populated to avoid errors
            if (movement != null)
            {
                // pass our movement input to our playerMovementScript
                movement.MovePlayer(horizontalInput * Vector2.right);
            }
            else
            {
                // In the unity console, say that there is no shooting script attached
                Debug.Log("Attach an EngineBase script");
            }
        }

        // if we press the Fire1 button
        if (Input.GetButton("Fire1") || Input.GetButton("Jump"))
        {
            // if our shootingScript is populated
            if (weapon != null)
            {
                // tell shootingScript to shoot
                weapon.Shoot();
            }
            else
            {
                // In the unity console, say that there is no shooting script attached
                Debug.Log("Attach a WeaponBase script");
            }
        }

        // if the timer is greater then zero start counting down
        if (powerupTimer > 0)
        {
            // count down the seconds by subtracting time from the timer
            powerupTimer -= Time.deltaTime;
            // when the timer runs out and equals zero
            if (powerupTimer <= 0)
            {
                // swap the weapon back to the machine gun
                SwapWeapon(WeaponType.machineGun);
            }
        }
    }

    /// <summary>
    /// SwapWeapon handles creating a new WeaponBase component based on the given weaponType. 
    /// This will popluate the newWeapon's controls and remove the existing weapon ready for usage.
    /// </summary>
    /// <param name="weaponType">The given weaponType to swap our current weapon to, this is an enum in WeaponBase.cs</param>
    public void SwapWeapon(WeaponType weaponType)
    {
        // make a new weapon dependent on the weaponType
        WeaponBase newWeapon = null;
        switch (weaponType)
        {
            case WeaponType.machineGun:
                newWeapon = gameObject.AddComponent<WeaponMachineGun>();
                break;
            case WeaponType.tripleShot:
                newWeapon = gameObject.AddComponent<WeaponTripleShot>();
                // When the triple shot pickup is collected the cooldown timer resets
                powerupTimer = powerupDuration;
                break;
        }

        // update the data of our newWeapon with that of our current weapon
        newWeapon.UpdateWeaponControls(weapon);
        // remove the old weapon
        Destroy(weapon);
        // set our current weapon to be the newWeapon
        weapon = newWeapon;
    }
}
