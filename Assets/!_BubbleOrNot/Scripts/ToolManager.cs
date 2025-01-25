
using UnityEngine;
using UnityEngine.InputSystem;

using BubbleOrNot.Utils;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class ToolManager : MonoBehaviour
    {
        [SerializeField] private Transform mouseFollower;
        [SerializeField] private LayerMask toolClickLayerMask;
        
        
        private Tool _equippedTool;
        private Camera _mainCamera;

        
        private void Awake()
        {
            _mainCamera = Camera.main;
        }


        #region INPUT

        public void OnClick(bool pressed)
        {
            if (_equippedTool) _equippedTool.OnClick(pressed);
            
            if (!pressed) return;
            
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
            Collider2D hitCollider = rayHit.collider;
            if (!hitCollider) return;
            
            Debug.Log("Clicked collider with name: " + hitCollider.name);
            
            if (!hitCollider.gameObject.layer.IsInMask(toolClickLayerMask)) return;
            
            var tool = hitCollider.GetComponentInParent<Tool>();
            if (tool) EquipTool(tool);
        }

        public void OnDrop(bool pressed)
        {
            if (!pressed) return;
            
            Unequip();
        }
        
        #endregion // INPUT


        #region INTERNAL
        
        private void EquipTool(Tool tool)
        {
            if (!tool) return;
            
            Unequip();
            
            _equippedTool = tool;
            _equippedTool.transform.SetParent(mouseFollower);
            _equippedTool.transform.localPosition = Vector3.zero;
            
            _equippedTool.OnEquipped();
        }
        
        private void Unequip()
        {
            if (!_equippedTool) return;
            
            _equippedTool.OnUnequipped();
            
            _equippedTool.transform.SetParent(transform);
            _equippedTool.Respawn();
            _equippedTool = null;
        }
        
        #endregion // INTERNAL
    }
}