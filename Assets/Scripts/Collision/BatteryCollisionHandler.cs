using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BatteryCollisionHandler : ICollisionHandler
{
    private EnergySystem energySystem;

    public BatteryCollisionHandler(EnergySystem energySystem)
    {
        this.energySystem = energySystem;
    }

    public void HandleCollision(Collision collision)
    {
        energySystem.AddEnergy(100);
        UnityEngine.Object.Destroy(collision.gameObject);
    }
}
