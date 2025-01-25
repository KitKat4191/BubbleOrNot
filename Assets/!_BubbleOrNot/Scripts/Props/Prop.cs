
using UnityEngine;
using BubbleOrNot.Runtime.Audio;

namespace BubbleOrNot.Runtime
{
    public enum ToolType
    {
        Alien,
        Hammer,
        Needle,
        Taser,
    }
    
    public class Prop : MonoBehaviour
    {
        [SerializeField] private AudioBundle alienSounds;
        [SerializeField] private AudioBundle hammerSounds;
        [SerializeField] private AudioBundle needleSounds;
        [SerializeField] private AudioBundle taserSounds;

        public virtual void OnToolUsed(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.Alien:
                    break;
                case ToolType.Hammer:
                    break;
                case ToolType.Needle:
                    break;
                case ToolType.Taser:
                    break;
                default:
                    Debug.LogWarning($"Tool type {toolType} is not supported");
                    break;
            }
        }
    }
}