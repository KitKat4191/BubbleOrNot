
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("BubbleOrNot/Tool")]
    public class Tool : MonoBehaviour
    {
        private static readonly int Using = Animator.StringToHash("Using");
        
        
        [SerializeField] private ToolType toolType;
        
        
        private Vector3 _spawnPosition;
        private Collider2D _collider;
        private Animator _animator;

        private void Awake()
        {
            _spawnPosition = transform.position;
            _collider = GetComponentInChildren<Collider2D>();
            _animator = GetComponent<Animator>();
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
            _animator.SetBool(Using, pressed);
            
            if (!pressed) return;
            if (!TryGetProp(out Prop prop)) return;
            
            prop.OnToolUsed(toolType);
        }

        
        private readonly Collider2D[] _colliderBuffer = new Collider2D[10];
        private bool TryGetProp(out Prop prop)
        {
            prop = null;
            
            int count = Physics2D.OverlapCircleNonAlloc(transform.position, 0.1f, _colliderBuffer, LayerMask.GetMask("Prop"));
            if (count <= 0) return false;
            
            prop = _colliderBuffer[0].GetComponentInParent<Prop>();
            return prop;
        }
    }
}