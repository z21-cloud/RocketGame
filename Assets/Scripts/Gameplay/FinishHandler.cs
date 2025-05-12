using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishHandler : ICollisionHandler
{
    private GameStateManager gameStateManager;
    public FinishHandler(GameStateManager gameStateManager)
    {
        this.gameStateManager = gameStateManager;
    }
    public void HandleCollision(Collision collision)
    {
        gameStateManager.Win();
    }
}
