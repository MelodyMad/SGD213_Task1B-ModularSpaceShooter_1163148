﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WeaponMachineGun handles the triple shot weapon of three shots being fired at once
/// </summary>
public class WeaponTripleShot : WeaponBase 
{
    /// <summary>
    /// Shoot will spawn a three bullets, provided enough time has passed compared to our fireDelay.
    /// </summary>
    public override void Shoot() 
    {
        // get the current time
        float currentTime = Time.time;
        // print("Shoot triple shot");

        // if enough time has passed since our last shot compared to our fireDelay, spawn our bullet
        if (currentTime - lastFiredTime > fireDelay) 
        {
            float x = -0.5f;
            // create 3 bullets
            for (int i = 0; i < 3; i++) 
            {
                // create our bullet
                GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
                // set their direction
                if (CompareTag("Player")) // if the shooter is the player
                {
                    newBullet.GetComponent<MoveConstantly>().Direction = new Vector2(x + 0.5f * i, 0.5f); // upwards
                }
                else  // if the shooter is the boss
                {
                    newBullet.GetComponent<MoveConstantly>().Direction = new Vector2(x + 0.5f * i, -0.5f); // downwards
                }
            }
            // update our shooting state
            lastFiredTime = currentTime;
        }
    }
}
