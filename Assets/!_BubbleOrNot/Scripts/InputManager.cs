
using UnityEngine;
using UnityEngine.InputSystem;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class InputManager : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            if (!context.started) return;
            
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
            if (!rayHit.collider) return;
            
            Debug.Log(rayHit.collider.gameObject.name);
        }
    }
}