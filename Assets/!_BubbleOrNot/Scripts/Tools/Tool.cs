
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

        private Prop _currentProp;
        
        
        private void Awake()
        {
            _spawnPosition = transform.position;
            _collider = GetComponent<Collider2D>();
            _animator = GetComponent<Animator>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!TryGetProp(other, out _currentProp)) return;
            if (_isUsing) _currentProp.OnToolUsed(toolType);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!TryGetProp(other, out Prop prop)) return;
            if (prop != _currentProp) return;
            
            _currentProp = null;
        }


        public void OnEquipped()
        {
            _collider.enabled = false;
        }

        public void OnUnequipped()
        {
            OnClick(false);
            _collider.enabled = true;
            transform.position = _spawnPosition;
        }

        private bool _isUsing;
        public void OnClick(bool pressed)
        {
            _isUsing = pressed;
            
            _animator.SetBool(Using, _isUsing);
            
            if (!pressed) return;
            
            if (_currentProp)
                _currentProp.OnToolUsed(toolType);
        }

        
        private readonly Collider2D[] _colliderBuffer = new Collider2D[10];
        private static bool TryGetProp(Collider2D other, out Prop prop)
        {
            prop = other.GetComponentInParent<Prop>();
            return prop;
        }
    }
}