using UnityEngine;

namespace Runtime.Common
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] audioClips;

        private int _audioClipIndex;

        public void PlaySX()
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
        }

        public void PlayConversation()
        {
            audioSource.clip = audioClips[_audioClipIndex];
            audioSource.Play();
            _audioClipIndex++; 
        }
    }
}