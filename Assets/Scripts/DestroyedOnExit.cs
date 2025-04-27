using UnityEngine;
using System.Collections;

/// <summary>
/// DestroyedOnExit is used when a game object is no longer visible on the screen and therefore it is destroyed
/// </summary>
public class DestroyedOnExit : MonoBehaviour
{
    // Called when the object leaves the viewport
    void OnBecameInvisible()
    {
        // Destroy the object once it is out of view
        Destroy(gameObject);
    }
}
