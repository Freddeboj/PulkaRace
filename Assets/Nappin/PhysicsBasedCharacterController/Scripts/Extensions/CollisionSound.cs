using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioClip[] playerSounds;
    public AudioClip[] otherObjectSounds;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerSounds.Length > 0)
            {
                AudioClip sound = playerSounds[Random.Range(0, playerSounds.Length)];
                PlaySound(sound);
            }
        }
        else if (!collision.gameObject.CompareTag("Hill"))
        {
            if (otherObjectSounds.Length > 0)
            {
                AudioClip sound = otherObjectSounds[Random.Range(0, otherObjectSounds.Length)];
                PlaySound(sound);
            }
        }
    }

    private void PlaySound(AudioClip sound)
    {
        audioSource.clip = sound;
        audioSource.Play();
    }
}
