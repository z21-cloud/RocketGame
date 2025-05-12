using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EnergySystem : MonoBehaviour
{
    [SerializeField] private int energy = 2000;
    public int CurrentEnergy => energy;
    [SerializeField] private TextMeshProUGUI energyText;

    public void AddEnergy(int amount)
    {
        energy += amount;
        GameEvents.TriggerEventChanged(energy);
    }

    public void ConsumeEnergy(int amount)
    {
        energy -= amount;
        GameEvents.TriggerEventChanged(energy); // Обновляем UI
    }
}
