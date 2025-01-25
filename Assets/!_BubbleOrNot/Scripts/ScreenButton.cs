
using UnityEngine;
using UnityEngine.Events;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class ScreenButton : Clickable
    {
        [SerializeField] private Animator animator;
        [SerializeField] private UnityEvent onClick;
        
        
        public override void OnClick(bool pressed)
        {
            animator.SetBool("Pressed", pressed);
            if (!pressed) onClick.Invoke();
        }
    }
}