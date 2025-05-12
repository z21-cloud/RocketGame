using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RocketConfig : ScriptableObject
{
    public float Speed = 10f;
    public float RotationSpeed = 10f;
    public int InitialEnergy = 1000;
}
