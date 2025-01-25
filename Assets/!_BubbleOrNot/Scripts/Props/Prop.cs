
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
        [SerializeField] private AudioBundle collisionSounds;


        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (collisionSounds) AudioManager.Instance.Play(collisionSounds);
        }


        public virtual void OnToolUsed(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.Alien:
                    if (alienSounds) AudioManager.Instance.Play(alienSounds);
                    break;
                case ToolType.Hammer:
                    if (hammerSounds) AudioManager.Instance.Play(hammerSounds);
                    break;
                case ToolType.Needle:
                    if (needleSounds) AudioManager.Instance.Play(needleSounds);
                    break;
                case ToolType.Taser:
                    if (taserSounds) AudioManager.Instance.Play(taserSounds);
                    break;
                default:
                    Debug.LogWarning($"Tool type {toolType} is not supported");
                    break;
            }
        }
    }
}