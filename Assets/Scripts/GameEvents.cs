using UnityEngine;  
using System;

public static class GameEvents 
{
    public static event Action<int> OnEnergyChanged;
    public static event Action OnWinSound;
    public static event Action OnWinEffect;
    public static event Action OnLoseSound;
    public static event Action OnLoseEffect;
    public static event Action OnThrustSound;
    public static event Action OnThrustEffect;

    public static void TriggerEventChanged(int energy) => OnEnergyChanged?.Invoke(energy);
    public static void TriggerWinSound() => OnWinSound?.Invoke();
    public static void TriggerWinEffect() => OnWinEffect?.Invoke();
    public static void TriggerLoseSound() => OnLoseSound?.Invoke();
    public static void TriggerLoseEffect() => OnLoseEffect?.Invoke();
    public static void TriggerThrustSound() => OnThrustSound?.Invoke();
    public static void TriggerThrustEffect() => OnThrustEffect?.Invoke();
}
