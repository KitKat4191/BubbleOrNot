
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
            if (_equippedTool)
            {
                _equippedTool.OnClick(pressed);
                return;
            }
            
            if (!pressed) return;
            if (TryGetTool(out Tool newTool)) EquipTool(newTool);
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
            Unequip();
            
            _equippedTool = tool;
            _equippedTool.transform.SetParent(mouseFollower);
            _equippedTool.transform.localPosition = Vector3.zero;
            
            _equippedTool.OnEquipped();
            
            Debug.Log($"Equipped tool '{_equippedTool.name}'");
        }
        
        private void Unequip()
        {
            if (!_equippedTool) return;

            Debug.Log($"Unequipping tool '{_equippedTool.name}'");
            
            _equippedTool.transform.SetParent(transform);
            _equippedTool.OnUnequipped();
            _equippedTool = null;
        }

        private const int _COLLIDER_BUFFER_LENGTH = 10;
        private readonly Collider2D[] _colliderBuffer = new Collider2D[_COLLIDER_BUFFER_LENGTH];
        private bool TryGetTool(out Tool tool)
        {
            tool = null;

            Vector3 pos = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            pos.z = 0;
            
            int count = Physics2D.OverlapCircleNonAlloc(pos, 0.1f, _colliderBuffer, LayerMask.GetMask("Tool"));
            if (count <= 0) return false;
            
            if (count >= _COLLIDER_BUFFER_LENGTH)
                count = _COLLIDER_BUFFER_LENGTH;

            for (int i = 0; i < count; i++)
            {
                tool = _colliderBuffer[i].GetComponent<Tool>();
                if (tool) break;
            }
            
            return tool;
        }
        
        #endregion // INTERNAL
    }
}