
using UnityEngine;

namespace BubbleOrNot.Runtime.Audio
{
    [AddComponentMenu("")]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance)
            {
                Destroy(this);
                return;
            }
            
            Instance = this;
            
            _audioSource = GetComponent<AudioSource>();
        }
        
        private AudioSource _audioSource;

        public void PlayClip(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}