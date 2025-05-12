using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private RocketInput input;
    public bool isMoveUpPressed => input.Player.MoveUp.IsPressed();
    public float RotationDirection=> input.Player.Rotate.ReadValue<float>();

    private void Awake()
    {
        input = new RocketInput();
        input.Player.Enable();
    }
}
