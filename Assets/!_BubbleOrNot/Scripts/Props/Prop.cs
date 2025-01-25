
using UnityEngine;
using BubbleOrNot.Runtime.Audio;
using Random = UnityEngine.Random;

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
        [SerializeField] protected bool isBubble;
        
        [Header("Settings")]
        [SerializeField] protected bool isFlushable = true;
        [SerializeField] protected Sprite displaySprite;
        
        [Header("Audio Settings")]
        [SerializeField] protected AudioBundle alienSounds;
        [SerializeField] protected AudioBundle hammerSounds;
        [SerializeField] protected AudioBundle needleSounds;
        [SerializeField] protected AudioBundle taserSounds;
        [SerializeField] protected AudioBundle collisionSounds;


        
        protected Animator _animator;
        protected Rigidbody2D _rigidbody;

        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        
        protected virtual void OnCollisionEnter2D(Collision2D _)
        {
            if (collisionSounds) AudioManager.Instance.Play(collisionSounds);
        }

        public bool IsFlushable => isFlushable;
        public Sprite DisplaySprite => displaySprite;
        public bool IsBubble => Random.Range(int.MinValue, int.MaxValue) > 0;
        
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
                    _animator.SetTrigger("Tazed");
                    break;
                default:
                    Debug.LogWarning($"Tool type {toolType} is not supported");
                    break;
            }
        }
    }
}