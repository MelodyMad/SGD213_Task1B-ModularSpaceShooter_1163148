using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Create a rigid body variable
    private Rigidbody2D rb;
    // Create an acceleration variable for object movement
    [SerializeField]
    private float m_acceleration = 50f;
    private float initialVelocity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Create a rigid body for 2D
        rb = GetComponent<Rigidbody2D>();

    }

    public void Move(Vector2 direction)
    {
        // Making the rigid body move in a direction multiplied by the acceleration and frame time
        rb.AddForce(direction * m_acceleration * Time.deltaTime);
    }

}

