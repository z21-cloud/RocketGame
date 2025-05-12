using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem flyParticle;
    [SerializeField] private ParticleSystem winParticle;
    [SerializeField] private ParticleSystem deathParticle;

    private void OnEnable()
    {
        GameEvents.OnThrustEffect += PlayFlyParticle;
        GameEvents.OnWinEffect += PlayWinParticle;
        GameEvents.OnLoseEffect += PlayDeathParticle;
    }

    private void OnDisable()
    {
        GameEvents.OnThrustEffect -= PlayFlyParticle;
        GameEvents.OnWinEffect -= PlayWinParticle;
        GameEvents.OnLoseEffect -= PlayDeathParticle;
    }

    public void PlayFlyParticle()
    {
        if (!flyParticle.isPlaying)
            flyParticle.Play();
    }

    public void StopFlyParticle()
    {
        if (flyParticle.isPlaying)
            flyParticle.Stop();
    }

    private void PlayWinParticle()
    {
        winParticle.Play();
    }

    private void PlayDeathParticle()
    {
        deathParticle.Play();
    }
}