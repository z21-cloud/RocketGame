using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitySceneLoader : ISceneLoader
{
    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
