using UnityEngine;
using System.Collections;

public class DestroyedOnExit : MonoBehaviour
{
    // Called when the object leaves the viewport
    void OnBecameInvisible()
    {
        // Destroy the object once it is out of view
        Destroy(gameObject);
    }
}
