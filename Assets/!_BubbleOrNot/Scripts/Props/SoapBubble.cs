
using UnityEngine;
using System.Diagnostics;
using BubbleOrNot.Runtime.Audio;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("BubbleOrNot/Props/SoapBubble")]
    public class SoapBubble : Prop
    {
        [Header("Soap Bubble Settings")]
        [SerializeField] private float timeBeforeCanDie = 1f;
        [SerializeField] private float timeBeforeDestroy;

        private Stopwatch _stopwatch;
        private void Start()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        protected override void OnCollisionEnter2D(Collision2D _) => Pop();
        public override void OnToolUsed(ToolType toolType) => Pop();

        private void Pop()
        {
            if (_stopwatch.Elapsed.TotalSeconds < timeBeforeCanDie) return;
            
            _rigidbody.isKinematic = true;
            _animator.SetTrigger("Pop");
            Destroy(gameObject, timeBeforeDestroy);
            
            if (collisionSounds) AudioManager.Instance.Play(collisionSounds);
        }
    }
}