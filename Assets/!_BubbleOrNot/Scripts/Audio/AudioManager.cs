
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

        public void Play(AudioBundle bundle)
        {
            AudioClip clip = bundle.GetClip;
            float volume = bundle.GetVolumeForClip(clip);
            
            _audioSource.PlayOneShot(clip, volume);
        }
        
        public void Play(AudioClip clip, float volume = 1.0f)
        {
            _audioSource.PlayOneShot(clip, volume);
        }
    }
}