
using UnityEngine;
using BubbleOrNot.Utils;

namespace BubbleOrNot.Runtime
{
    [CreateAssetMenu(menuName = "BubbleOrNot/AudioBundle", fileName = "AudioBundleName")]
    public class AudioBundle : ScriptableObject
    {
        [SerializeField] private AudioClip[] audioClips;
        
        
        private int _lastClipIndex;
        
        
        public AudioClip GetRandom
        {
            get
            {
                _lastClipIndex++;
                if (_lastClipIndex >= audioClips.Length)
                {
                    _lastClipIndex = 0;
                    audioClips.Shuffle();
                }
                return audioClips[_lastClipIndex];
            }
        }
    }
}