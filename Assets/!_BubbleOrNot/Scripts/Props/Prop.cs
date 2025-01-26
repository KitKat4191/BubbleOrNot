
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
        Umbrella
    }
    
    public class Prop : MonoBehaviour
    {
        private static readonly int Zorbed = Animator.StringToHash("Zorbed");
        private static readonly int Smacked = Animator.StringToHash("Smacked");
        private static readonly int Poked = Animator.StringToHash("Poked");
        private static readonly int Tazed = Animator.StringToHash("Tazed");
        private static readonly int Umbrellaed = Animator.StringToHash("Umbrellaed");


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
                    _animator.SetTrigger(Zorbed);
                    _animator.SetBool(Zorbed, true);
                    _animator.SetInteger(Zorbed, _animator.GetInteger(Zorbed) + 1);
                    break;
                case ToolType.Hammer:
                    if (hammerSounds) AudioManager.Instance.Play(hammerSounds);
                    _animator.SetTrigger(Smacked);
                    _animator.SetBool(Smacked, true);
                    _animator.SetInteger(Smacked, _animator.GetInteger(Smacked) + 1);
                    break;
                case ToolType.Needle:
                    if (needleSounds) AudioManager.Instance.Play(needleSounds);
                    _animator.SetTrigger(Poked);
                    _animator.SetBool(Poked, true);
                    _animator.SetInteger(Poked, _animator.GetInteger(Poked) + 1);
                    break;
                case ToolType.Taser:
                    if (taserSounds) AudioManager.Instance.Play(taserSounds);
                    _animator.SetTrigger(Tazed);
                    _animator.SetBool(Tazed, true);
                    _animator.SetInteger(Tazed, _animator.GetInteger(Tazed) + 1);
                    break;
                case ToolType.Umbrella:
                    _animator.SetTrigger(Umbrellaed);
                    _animator.SetBool(Umbrellaed, true);
                    _animator.SetInteger(Umbrellaed, _animator.GetInteger(Umbrellaed) + 1);
                    break;
                default:
                    Debug.LogWarning($"Tool type {toolType} is not supported");
                    break;
            }
        }
    }
}