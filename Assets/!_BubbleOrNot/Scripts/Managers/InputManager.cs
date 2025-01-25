
using UnityEngine;
using UnityEngine.InputSystem;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private ToolManager toolManager;
        
        
        private Camera _mainCamera;
        private Clickable _currentClickable;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            if (context.started) toolManager.OnClick(true);
            if (context.canceled) toolManager.OnClick(false);

            if (context.started)
            {
                RaycastHit2D rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
                Collider2D hitCollider = rayHit.collider;
                if (!hitCollider) return;

                _currentClickable = hitCollider.GetComponent<Clickable>();
                if (_currentClickable) _currentClickable.OnClick(true);
            }

            if (context.canceled)
            {
                if (_currentClickable) _currentClickable.OnClick(false);
            }
        }

        public void OnDrop(InputAction.CallbackContext context)
        {
            if (context.started) toolManager.OnDrop(true);
            if (context.canceled) toolManager.OnDrop(false);
        }
    }
}