using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDirectionController : MonoBehaviour
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
        // The movement is applied to this object
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Controllable direction that any object can use
        movement.Move(direction);
    }
}
