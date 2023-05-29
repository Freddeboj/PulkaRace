using UnityEngine;
using System.Collections.Generic;

namespace PhysicsBasedCharacterController
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio specifics")]
        public AudioClip audioOnFast;
        public List<AudioClip> audioClipsOnTurn = new List<AudioClip>();

        private AudioSource audioSource;
        private AudioClip currentClip;


        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void CalledOnFast()
        {
            if (currentClip == audioOnFast && audioSource.isPlaying)
            {
                return;
            }

            PlaySound(audioOnFast);
        }

        public void CalledOnTurn()
        {
            if (audioSource.isPlaying)
            {
                return;
            }

            PlayRandomClip();
        }

        private void PlaySound(AudioClip clip)
        {
            currentClip = clip;

            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }

        private void PlayRandomClip()
        {
            if (audioClipsOnTurn.Count == 0)
            {
                return;
            }

            int randomIndex = Random.Range(0, audioClipsOnTurn.Count);
            AudioClip randomClip = audioClipsOnTurn[randomIndex];

            audioSource.Stop();
            audioSource.clip = randomClip;
            audioSource.Play();
        }
    }
}
