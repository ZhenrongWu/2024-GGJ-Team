using UnityEngine;

namespace Runtime.Common
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] audioClips;

        public void PlaySX()
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
        }
    }
}