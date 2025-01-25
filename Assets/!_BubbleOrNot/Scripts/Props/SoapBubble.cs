
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("BubbleOrNot/Props/SoapBubble")]
    public class SoapBubble : Prop
    {
        [Header("Soap Bubble Settings")]
        [SerializeField] private float timeBeforeDestroy;
        
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            base.OnCollisionEnter2D(other);
            Pop();
        }

        public override void OnToolUsed(ToolType toolType)
        {
            base.OnToolUsed(toolType);
            Pop();
        }

        private void Pop()
        {
            _rigidbody.isKinematic = true;
            _animator.SetTrigger("Pop");
            Destroy(gameObject, timeBeforeDestroy);
        }
    }
}