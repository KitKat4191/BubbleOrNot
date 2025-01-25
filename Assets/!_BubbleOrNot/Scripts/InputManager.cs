
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
            
            if (!context.started) return;
            
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
            if (!rayHit.collider) return;
            
            Debug.Log("Clicked collider with name: " + rayHit.collider.gameObject.name);

            if (!toolManager) return;
            
            string tag = rayHit.collider.gameObject.tag;

            switch (tag)
            {
                case "Prop":
                    var prop = rayHit.collider.GetComponentInParent<Prop>();
                    if (prop) toolManager.OnClickedProp(prop);
                    break;
                case "Tool":
                    var tool = rayHit.collider.GetComponentInParent<Tool>();
                    if (tool) toolManager.OnClickedTool(tool);
                    break;
            }
        }

        public void OnDrop(InputAction.CallbackContext context)
        {
            if (context.started) toolManager.OnDrop(true);
            if (context.canceled) toolManager.OnDrop(false);
        }
    }
}