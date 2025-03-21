using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float m_fireDelay = 1f;

    private float m_lastFiredTime = 0f;
    private float m_bulletOffset = 2f;

    void Start()
    {
        // Math to perfectly spawn bullets in front of the Spaceship
        m_bulletOffset = GetComponent<Renderer>().bounds.size.y / 2 // Half of our size
            + bullet.GetComponent<Renderer>().bounds.size.y / 2; // Plus half of the bullet size
    }

    public void Shoot()
    {
        float CurrentTime = Time.time;
        // Have a delay to stop too many bullets from spawning at once
        if (CurrentTime - m_lastFiredTime > m_fireDelay)
        {
            // Spawn and then fire the bullet
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + m_bulletOffset);
            Instantiate(bullet, spawnPosition, transform.rotation);
            m_lastFiredTime = CurrentTime;
        }
    }
}
