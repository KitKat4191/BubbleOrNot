
using UnityEngine;
using UnityEngine.InputSystem;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private ToolManager toolManager;
        
        
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            if (context.started) toolManager.OnClick(true);
            if (context.canceled) toolManager.OnClick(false);
        }

        public void OnDrop(InputAction.CallbackContext context)
        {
            if (context.started) toolManager.OnDrop(true);
            if (context.canceled) toolManager.OnDrop(false);
        }
    }
}