using UnityEngine;

public class StartParticleEffectDelayed : MonoBehaviour
{
    public ParticleSystem particleEffect;
    public ParticleSystem subEmitter;
    public float delay = 120f; // Two minutes in seconds

    private float timer = 0f;
    private bool isActivated = false;

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if the delay time has passed
        if (!isActivated && timer >= delay)
        {
            // Activate the particle effect
            particleEffect.Play();
            isActivated = true;

            // Activate the sub emitter
            if (subEmitter != null)
            {
                ParticleSystem subParticleSystem = subEmitter.GetComponent<ParticleSystem>();
                if (subParticleSystem != null)
                {
                    subParticleSystem.Play();
                }
            }
        }
    }
}
