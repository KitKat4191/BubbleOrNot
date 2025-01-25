
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("BubbleOrNot/Tool")]
    public class Tool : MonoBehaviour
    {
        private static readonly int Using = Animator.StringToHash("Using");
        
        
        [SerializeField] private ToolType toolType;
        [SerializeField] private Animator animator;
        
        
        private Vector3 _spawnPosition;

        private void Awake()
        {
            _spawnPosition = transform.position;
        }


        public void Respawn()
        {
            transform.position = _spawnPosition;
        }

        public void OnEquipped()
        {
            
        }

        public void OnUnequipped()
        {
            
        }

        public void OnClick(bool pressed)
        {
            animator.SetBool(Using, pressed);
        }
    }
}