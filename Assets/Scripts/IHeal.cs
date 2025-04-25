using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IHeal defines how to speak to any healing component
/// </summary>
public interface IHeal
{
    // get the amount of health this health component currently has
    int CurrentHealth { get; }
    // get the maximum health of this health component
    int MaxHealth { get; }

    /// <summary>
    /// Heal handles the functionality of receiving health
    /// </summary>
    /// <param name="healingAmount">The amount of health to gain, this value should be positive</param>
    void Heal(int healingAmount);
}