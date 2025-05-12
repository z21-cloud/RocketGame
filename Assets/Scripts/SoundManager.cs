using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip flySound;
    [SerializeField] private AudioClip boomSound;
    [SerializeField] private AudioClip winSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameEvents.OnThrustSound += PlayFlySound;
        GameEvents.OnWinSound += PlayWinSound;
        GameEvents.OnLoseSound += PlayBoomSound;
    }

    private void OnDisable()
    {
        GameEvents.OnThrustSound -= PlayFlySound;
        GameEvents.OnWinSound -= PlayWinSound;
        GameEvents.OnLoseSound -= PlayBoomSound;
    }

    public void PlayFlySound()
    {
        if (!audioSource.isPlaying) audioSource.PlayOneShot(flySound);
    }

    public void StopFlySound()
    {
        if (audioSource.isPlaying) audioSource.Stop();
    }

    public void PlayBoomSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(boomSound);
    }

    public void PlayWinSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}
