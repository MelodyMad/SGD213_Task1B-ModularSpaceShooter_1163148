using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamage
{
    [SerializeField]
    protected int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField]
    protected int maxHealth;
    public int MaxHealth { get { return maxHealth; } }

    [SerializeField]
    private Slider EnemyHealthSlider;

    void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// TakeDamage handles the functionality for taking damage
    /// </summary>
    /// <param name="damageAmount">The amount of damage to lose, this value should be positive</param>

    public void TakeDamage(int damageAmount)
    {
        if (gameObject.tag == "Boss")
        {
            currentHealth -= damageAmount;
            EnemyHealthSlider.value = ((float)currentHealth / (float)maxHealth);
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    /// <summary>
    /// Handles all functionality related to when health reaches or goes below zero, should perform all necessary cleanup.
    /// </summary>
    public void Die()
    {
        // would be good to do some death animation here maybe
        // remove this object from the game
        Destroy(gameObject);
    }
}
