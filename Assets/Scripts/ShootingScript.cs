﻿using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float fireDelay = 0.5f;

    private float lastFiredTime = 0f;
    private float bulletOffset = 1f;

    void Start()
    {
        // Math to perfectly spawn bullets in front of the Spaceship
        bulletOffset = GetComponent<Renderer>().bounds.size.y / 2 // Half of our size
            + bullet.GetComponent<Renderer>().bounds.size.y / 2; // Plus half of the bullet size
    }

    public void Shoot()
    {
        float CurrentTime = Time.time;
        // Have a delay to stop too many bullets from spawning at once
        if (CurrentTime - lastFiredTime > fireDelay)
        {
            // Spawn and then fire the bullet
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + bulletOffset);
            Instantiate(bullet, spawnPosition, transform.rotation);
            lastFiredTime = CurrentTime;
        }
    }
}
