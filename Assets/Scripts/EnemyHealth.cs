using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// EnemyHealth handles all of the health aspects relating to any enemy
/// including damage, death, healing, and a health bar
/// </summary>
public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    protected int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField]
    protected int maxHealth;
    public int MaxHealth { get { return maxHealth; } }

    // health bar
    [SerializeField]
    private Slider enemyHealthSlider;

    void Start()
    {
        // set the current health to max health
        currentHealth = maxHealth;
    }

    /// <summary>
    /// TakeDamage handles the functionality for taking damage
    /// </summary>
    /// <param name="damageAmount">The amount of damage to lose, this value should be positive</param>
    public void TakeDamage(int damageAmount)
    {
        // the amount of damage taken is subtracted from the current health
        currentHealth -= damageAmount;
        // the health bar is updated
        UpdateEnemyHealthSlider((float)currentHealth / (float)maxHealth);
        // if there is no more health then the object is destroyed
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

    /// The Heal method is required due to inheriting from the IHealth interface however the enemy does not heal, although it has the capabilities to do so.
    public void Heal(int healingAmount)
    {
        // Do nothing because the enemy is not meant to heal, however if the feature was desired the script below is a starting point to implement that feature
        /// currentHealth += healingAmount;
        /// UpdateEnemyHealthSlider((float)currentHealth / (float)maxHealth);
        /// if (currentHealth > maxHealth)
        /// {
        ///     currentHealth = maxHealth;
        /// }
    }

    /// <summary>
    /// UpdateEnemyHealthSlider handles the value of the health bar by calculating the percentage to provide values for the slider to slide
    /// if no health bar is assigned then it is stated in the consol
    /// </summary>
    public void UpdateEnemyHealthSlider(float percentage)
    {
        if (enemyHealthSlider != null)
        {
            enemyHealthSlider.value = percentage;
        }
        else
        {
            Debug.Log("Enemy health slider is not assigned!");
        }
    }

}
