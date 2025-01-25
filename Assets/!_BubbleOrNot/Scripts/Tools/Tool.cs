
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("BubbleOrNot/Tool")]
    public class Tool : MonoBehaviour
    {
        private static readonly int Using = Animator.StringToHash("Using");
        
        
        [SerializeField] private ToolType toolType;
        [SerializeField] private bool repeatUseWhileHeld;
        [SerializeField] private float repeatInterval = 0.5f;
        
        
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
            if (_isUsing && _currentProp) _currentProp.OnToolUsed(toolType);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!TryGetProp(other, out Prop prop)) return;
            if (prop != _currentProp) return;
            
            _currentProp = null;
        }


        private float _elapsedTime;
        private void Update()
        {
            if (!_isUsing) return;
            if (!repeatUseWhileHeld) return;
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime < repeatInterval) return;
            _elapsedTime = 0;
            if (_currentProp) _currentProp.OnToolUsed(toolType);
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
        
        private static bool TryGetProp(Collider2D other, out Prop prop)
        {
            prop = other.GetComponentInParent<Prop>();
            return prop;
        }
    }
}