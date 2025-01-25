
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
        private Collider _collider;

        private void Awake()
        {
            _spawnPosition = transform.position;
            _collider = GetComponentInChildren<Collider>();
        }
        

        public void OnEquipped()
        {
            _collider.enabled = false;
        }

        public void OnUnequipped()
        {
            _collider.enabled = true;
            transform.position = _spawnPosition;
        }

        public void OnClick(bool pressed)
        {
            animator.SetBool(Using, pressed);
        }
    }
}