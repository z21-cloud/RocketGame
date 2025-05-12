using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 25f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private ParticleManager particleManager;
    [SerializeField] private EnergySystem energySystem;
    [SerializeField] private GameStateManager gameStateManager;


    private Rigidbody rb;

    private void Awake()
    {
        if (inputManager == null)
            inputManager = FindObjectOfType<InputManager>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        if (gameStateManager.CurrentState != GameStateManager.State.Playing)
        {
            return;
        }
        
        if (energySystem.CurrentEnergy <= 0) return;

        if (inputManager.isMoveUpPressed)
        {
            Debug.Log("etxt");
            rb.AddRelativeForce(Vector3.up * speed, ForceMode.Force);
            GameEvents.TriggerThrustSound();
            GameEvents.TriggerThrustEffect();
        }
        else
        {
            FindObjectOfType<ParticleManager>()?.StopFlyParticle();
            FindObjectOfType<SoundManager>()?.StopFlySound();
        }
    }

    public void Rotate()
    {
        rb.freezeRotation = true;
        float direction = inputManager.RotationDirection;
        if (direction != 0)
        {
            float angle = direction * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, angle);
        }
        rb.freezeRotation = false;
    }
}
