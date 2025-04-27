using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WeaponBase is an interface that handles all of the weapon information and methods
/// </summary>
public abstract class WeaponBase : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField]
    protected float fireDelay = 0.6f;

    // bullet prefab
    [SerializeField]
    protected GameObject bullet;
    public GameObject Bullet
    {
        get { return bullet; }
        set { bullet = value; }
    }

    // location bullet will spawn
    [Header("References")]
    [SerializeField]
    protected Transform bulletSpawnPoint;
    public Transform BulletSpawnPoint
    {
        get { return bulletSpawnPoint; }
        set { bulletSpawnPoint = value; }
    }

    // State
    protected float lastFiredTime = 0f;

    /// <summary>
    /// Shoot is intended to be the access point for shooting mechanics. In concrete implementations it is intended that it 
    /// should only fire when enough time has passed compared to our fireDelay.
    /// </summary>
    public abstract void Shoot();

    /// <summary>
    /// UpdateWeaponControls takes an existing WeaponBase and populates the controls of this WeaponBase with
    /// those of the given WeaponBase
    /// </summary>
    /// <param name="oldWeapon">The existing weapon that will be used to grab WeaponBase controls from</param>
    public virtual void UpdateWeaponControls(WeaponBase oldWeapon)
    {
        // update the data of the new weapon with the data from this weapon
        bulletSpawnPoint = oldWeapon.BulletSpawnPoint;
        bullet = oldWeapon.Bullet;
    }
}
