using UnityEngine;
using System.Collections;

/// <summary>
/// Rotate handles the rotation of objects that this script is applied to
/// </summary>
public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float maximumSpinSpeed = 200;

    // Use this for initialization
    void Start()
    {
        // Set the object to rotate at a random Spin Speed between the parameters
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-maximumSpinSpeed, maximumSpinSpeed);
    }
}
