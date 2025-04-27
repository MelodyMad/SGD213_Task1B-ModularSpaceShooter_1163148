using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UIManager handles the UI that is visible on the game screeen and affecting the Player
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    // player health bar
    [SerializeField]
    private Slider sldPlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) 
        {
            Debug.LogError("There is more than one UIManager in the scene, this will break the Singleton pattern.");
        }
        instance = this;
    }

    // update the players health bar so that it changes based on damage taken and healing pickups
    public void UpdatePlayerHealthSlider(float percentage) 
    {
        sldPlayerHealth.value = percentage;
    }
}
