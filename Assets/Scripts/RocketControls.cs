using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControls : MonoBehaviour
{
    [SerializeField] private EnergySystem energySystem; 
    [SerializeField] private GameStateManager gameStateManager;
    private Dictionary<string, ICollisionHandler> collisionHandlers;

    private void Start()
    {
        collisionHandlers = new Dictionary<string, ICollisionHandler>
        {
            { "Battery", new BatteryCollisionHandler(energySystem) },
            { "Finish", new FinishHandler(gameStateManager) },
            { "Dangerous", new  DangerousHandler(gameStateManager) }
        };
    }

    /*private void DebugKey()
    {
        if(input.Player.LoadLevel.triggered)
        {
            Win();
        }
        else if(input.Player.GodMove.triggered)
        {
            collisionOff = !collisionOff;
            Debug.Log($"Godmode active: {collisionOff}");
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collisionHandlers.TryGetValue(collision.gameObject.tag, out var handler))
        {
            handler.HandleCollision(collision);
        }
    }
}
