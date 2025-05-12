using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI energyText;

    private void OnEnable()
    {
        GameEvents.OnEnergyChanged += UpdateEnergyUI;
    }

    private void OnDisable()
    {
        GameEvents.OnEnergyChanged -= UpdateEnergyUI;
    }

    private void UpdateEnergyUI(int energy)
    {
        if (energyText != null)
            energyText.text = energy.ToString();
        else
            Debug.LogError("energyText не назначен!");
    }
}
