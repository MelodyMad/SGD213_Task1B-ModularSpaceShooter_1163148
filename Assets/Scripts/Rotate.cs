using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float m_maximumSpinSpeed = 200;

    // Use this for initialization
    void Start()
    {
        // Set the object to rotate at a random Spin Speed between the parameters
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-m_maximumSpinSpeed, m_maximumSpinSpeed);
    }
}
