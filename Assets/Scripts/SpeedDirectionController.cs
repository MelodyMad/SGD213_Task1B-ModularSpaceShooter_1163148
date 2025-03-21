using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDirectionController : MonoBehaviour
{
    // Create a variable of the direction of a 2D vector
    [SerializeField]
    private Vector2 direction;
    [SerializeField]
    private Vector2 velocityDirection;

    // Create a variable from the Movement script named movement
    [SerializeField]
    private Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        // The movement is applied to this object
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Controllable directions that any object can use when this script is applied
        movement.Move(direction);
        movement.Velocity(velocityDirection);
    }
}
