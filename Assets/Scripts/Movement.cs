using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Create an acceleration and velocity variables for object movement
    [SerializeField]
    private float m_acceleration = 2000f;
    [SerializeField]
    private float m_velocity = 5f;

    // Create a rigid body variable
    private Rigidbody2D m_rb;

    // Start is called before the first frame update
    void Start()
    {
        // Create a rigid body for the 2D object
        m_rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        // Making the rigid body move in a direction multiplied by the acceleration and frame time
        m_rb.AddForce(direction * m_acceleration * Time.deltaTime);
    }

    public void Velocity(Vector2 velocityDirection)
    {
        // Create velocity by multiplying initial velocity by a direction
        m_rb.velocity = velocityDirection * m_velocity; 
    }
}

