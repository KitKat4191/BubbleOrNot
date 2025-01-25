
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
            Debug.Log("OnClick : " + pressed, this);
            animator.SetBool("Pressed", pressed);
            if (!pressed) onClick.Invoke();
        }
    }
}