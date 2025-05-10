using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RocketControls : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 25f;
    [SerializeField] private AudioClip flySound;
    [SerializeField] private AudioClip boomSound;
    [SerializeField] private AudioClip winSound;

    private enum State
    {
        Playing,
        Death,
        Win
    }

    private State state = State.Playing;
    private RocketInput input;
    private Rigidbody rb;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        state = State.Playing;
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        input = new RocketInput();
        input.Player.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        if (state == State.Playing)
        {
            RocketLaunch();
            RocketRotation();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Playing) return;

        switch (collision.gameObject.tag)
        {
            case "Safe":
                Debug.Log("Fine");
                break;
            case "Battery":
                Debug.Log("+1 energy");
                Destroy(collision.gameObject);
                break;
            case "Finish":
                state = State.Win;
                audioSource.Stop();
                audioSource.PlayOneShot(winSound);
                StartCoroutine(LoadLevelWithDelay(1));
                break;
            default:
                state = State.Death;
                audioSource.Stop();
                audioSource.PlayOneShot(boomSound);
                input.Disable(); // Отключаем Input Actions
                StartCoroutine(LoadLevelWithDelay(0));
                break;
        }
    }

    private IEnumerator LoadLevelWithDelay(int sceneID, float delay = 2.5f)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneID);
        Destroy(this.gameObject);
    }

    private void RocketLaunch()
    {
        if (input.Player.MoveUp.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * speed, ForceMode.Force);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(flySound);
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
