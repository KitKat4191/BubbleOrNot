
using UnityEngine;
using BubbleOrNot.Utils;

namespace BubbleOrNot.Runtime
{
    [CreateAssetMenu(menuName = "BubbleOrNot/AudioBundle", fileName = "AudioBundleName")]
    public class AudioBundle : ScriptableObject
    {
        [SerializeField] private AudioClip[] audioClips;
        
        
        private int _lastClipIndex;
        private AudioClip _lastClip;
        
        
        public AudioClip GetRandom
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
    }
}