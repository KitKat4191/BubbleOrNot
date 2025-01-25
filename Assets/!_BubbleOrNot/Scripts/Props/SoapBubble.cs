
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("BubbleOrNot/Props/SoapBubble")]
    public class SoapBubble : Prop
    {
        [SerializeField] private float timeBeforeDestroy;
        
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            base.OnCollisionEnter2D(other);
            Destroy(gameObject, timeBeforeDestroy);
        }

        public override void OnToolUsed(ToolType toolType)
        {
            base.OnToolUsed(toolType);
            Destroy(gameObject, timeBeforeDestroy);
        }
    }
}