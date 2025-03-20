using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    // Create a variable of the direction of a 2D vector
    [SerializeField]
    private Vector2 direction;
    // Create a variable from the Movement script named movement
    [SerializeField]
    private Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Controlable direction that any object can use
        movement.Move(direction);
    }
}
