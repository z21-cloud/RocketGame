using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private RocketInput input;
    // Start is called before the first frame update
    private void Start()
    {
        input = new RocketInput();
        input.Player.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        if(input.Player.MoveUp.triggered)
        {
            SceneManager.LoadScene(1);
        }
    }
}
