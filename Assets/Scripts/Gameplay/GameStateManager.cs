using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private ISceneLoader sceneLoader;
    
    public enum State { Playing, Death, Win }
    private State currentState = State.Playing;
    public State CurrentState => currentState;

    private int currentId = 0;
    private static GameStateManager instance;

    private void Awake()
    {
        if (sceneLoader == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (sceneLoader == null)
            sceneLoader = new UnitySceneLoader();

        currentState = State.Playing;
    }

    public void Win()
    {
        if(currentState == State.Playing)
        {
            GameEvents.TriggerWinSound();
            GameEvents.TriggerWinEffect();
        }
        currentState = State.Win;
        currentId += 1;
        StartCoroutine(LoadLevelWithDelay(currentId));
    }

    public void Lose()
    {
        if (currentState == State.Playing)
        {
            GameEvents.TriggerLoseEffect();
            GameEvents.TriggerLoseSound();
        }
        currentState = State.Death;
        currentId = 1;
        StartCoroutine(LoadLevelWithDelay(currentId));
    }

    private IEnumerator LoadLevelWithDelay(int sceneId, float delay = 2.5f)
    {
        yield return new WaitForSeconds(delay);
        sceneLoader.LoadScene(sceneId);
    }
}
