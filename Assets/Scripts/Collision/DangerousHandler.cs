using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousHandler : ICollisionHandler
{
    private GameStateManager gameStateManager;
    public DangerousHandler(GameStateManager gameStateManager)
    {
        this.gameStateManager = gameStateManager;
    }
    public void HandleCollision(Collision collision)
    {
        gameStateManager.Lose();
    }
}