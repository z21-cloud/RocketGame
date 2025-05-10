using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControls : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 25f;
    [SerializeField] private AudioSource audioSource;

    private RocketInput input;
    private Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        input = new RocketInput();
        input.Player.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        RocketLaunch();
        RocketRotation();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Safe":
                Debug.Log("Fine");
                break;
            case "Battery":
                Debug.Log("+1 energy");
                Destroy(collision.gameObject);
                break;
            default:
                // Останавливаем звук и отключаем систему ввода
                audioSource.Stop();
                input.Disable(); // Отключаем Input Actions

                // Уничтожаем текущую ракету
                Destroy(this.gameObject);
                break;
        }
    }

    private void RocketLaunch()
    {
        if (input.Player.MoveUp.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * speed, ForceMode.Force);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Pause();
        }
    }

    private void RocketRotation()
    {
        rb.freezeRotation = true;
        if (input.Player.Rotate.IsPressed())
        {
            float direction = input.Player.Rotate.ReadValue<float>();
            float angle = direction * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, angle);
        }
        rb.freezeRotation = false;
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
