
using UnityEngine;
using BubbleOrNot.Utils;

namespace BubbleOrNot.Runtime.Audio
{
    [CreateAssetMenu(menuName = "BubbleOrNot/AudioBundle", fileName = "AudioBundleName")]
    public class AudioBundle : ScriptableObject
    {
        [Header("Settings")]
        [SerializeField] private AudioClip[] audioClips;
        [Range(0, 1)]
        [SerializeField] private float[] volumes;
        
        [Space]
        [Range(0, 1)]
        [SerializeField] private float masterVolume;
        
        [Space]
        [SerializeField] private bool randomizePitch;
        [SerializeField] private float minPitchVariation;
        [SerializeField] private float maxPitchVariation;
        
        
        private int _lastClipIndex;
        private AudioClip _lastClip;
        
        
        public bool RandomizePitch => randomizePitch;
        public float MinPitchVariation => minPitchVariation;
        public float MaxPitchVariation => maxPitchVariation;
        
        
        public AudioClip GetClip
        {
            get
            {
                int newClipIndex = _lastClipIndex + 1;
                
                if (newClipIndex >= audioClips.Length)
                {
                    newClipIndex = 0;
                    audioClips.Shuffle();
                }
                
                AudioClip clipToReturn = audioClips[newClipIndex];

                if (clipToReturn == _lastClip)
                {
                    newClipIndex++;
                    if (newClipIndex >= audioClips.Length)
                        newClipIndex = 0;
                    
                    clipToReturn = audioClips[newClipIndex];
                }
                
                _lastClipIndex = newClipIndex;
                _lastClip = clipToReturn;
                
                return clipToReturn;
            }
        }

        public float GetVolumeForClip(AudioClip clip)
        {
            if (!clip) return 0;
            
            int index = System.Array.IndexOf(audioClips, clip);
            if (index < 0) return 0;

            return volumes[index] * masterVolume;
        }
    }
}