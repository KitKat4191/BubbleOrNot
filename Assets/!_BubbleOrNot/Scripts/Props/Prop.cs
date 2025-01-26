
using UnityEngine;
using JetBrains.Annotations;
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
        
        [Space]
        [SerializeField] protected AudioBundle lightCollisionSounds;
        [SerializeField] protected AudioBundle mediumCollisionSounds;
        [SerializeField] protected AudioBundle hardCollisionSounds;
        
        [Space]
        [SerializeField] protected float lightCollisionThreshold;
        [SerializeField] protected float mediumCollisionThreshold;
        [SerializeField] protected float hardCollisionThreshold;

        
        protected Animator _animator;
        protected Rigidbody2D _rigidbody;

        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            float speed = collision.relativeVelocity.magnitude;
            if (speed > hardCollisionThreshold)
                if (hardCollisionSounds) AudioManager.Instance.Play(hardCollisionSounds);
            if (speed > mediumCollisionThreshold)
                if (mediumCollisionSounds) AudioManager.Instance.Play(mediumCollisionSounds);
            if (speed > lightCollisionThreshold)
                if (lightCollisionSounds) AudioManager.Instance.Play(lightCollisionSounds);
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

        public void OnToolStopUse()
        {
            _animator.SetBool(Zorbed, false);
            _animator.SetBool(Smacked, false);
            _animator.SetBool(Poked, false);
            _animator.SetBool(Tazed, false);
            _animator.SetBool(Umbrellaed, false);
        }

        #region ANIMATOR EVENT API

        [PublicAPI] // Called by animator event
        public void DestroyProp() => Destroy(gameObject, 0.1f);
        
        // AUDIO

        [PublicAPI] // Called by animator event
        public void PlaySoundAlien()
        {
            if (alienSounds) AudioManager.Instance.Play(alienSounds);
        }
        
        [PublicAPI] // Called by animator event
        public void PlaySoundHammer()
        {
            if (hammerSounds) AudioManager.Instance.Play(hammerSounds);
        }
        
        [PublicAPI] // Called by animator event
        public void PlaySoundNeedle()
        {
            if (needleSounds) AudioManager.Instance.Play(needleSounds);
        }
        
        [PublicAPI] // Called by animator event
        public void PlaySoundTaser()
        {
            if (taserSounds) AudioManager.Instance.Play(taserSounds);
        }
        
        #endregion // ANIMATOR EVENT API
    }
}