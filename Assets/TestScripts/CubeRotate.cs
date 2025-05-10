using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using static UnityEngine.GridBrushBase;

public class CubeRotate : MonoBehaviour
{
    [SerializeField] private float speedRotation = 10f;

    private bool isRotating = false;
    private CubeAction input;
    private RotationAxis currentAxis = RotationAxis.X;

    private enum RotationAxis
    {
        X,
        Y,
        Z
    }

    private void Awake()
    {
        input = new CubeAction();
        input.Cube.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.Cube.Rotate.triggered)
        {
            isRotating = !isRotating;
        }

        if (input.Cube.ChangeRotation.triggered)
        {
            CycleAxis();
        }

        if (isRotating)
        {
            Vector3 axis = GetVectorFromAxis(currentAxis);
            transform.Rotate(axis * speedRotation * Time.deltaTime);
        }
    }

    private Vector3 GetVectorFromAxis(RotationAxis axis)
    {
        return axis switch
        {
            RotationAxis.X => Vector3.right,
            RotationAxis.Y => Vector3.up,
            RotationAxis.Z => Vector3.forward,
            _ => Vector3.zero
        };
    }

    private void CycleAxis()
    {
        currentAxis = currentAxis switch
        {
            RotationAxis.X => RotationAxis.Y,
            RotationAxis.Y => RotationAxis.Z,
            RotationAxis.Z => RotationAxis.X,
            _ => currentAxis
        };

        Debug.Log($"Текущая ось вращения {currentAxis}");
    }
}
