
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class ToolManager : MonoBehaviour
    {
        [SerializeField] private Transform mouseFollower;
        
        private Tool _equippedTool;

        
        public void OnClickedTool(Tool newTool)
        {
            if (!newTool) return;
            EquipTool(newTool);
        }

        public void OnClickedProp(Prop prop)
        {
            if (!prop) return;
            if (!_equippedTool) return;
            
            _equippedTool.transform.SetParent(mouseFollower);
        }

        public void OnClick(bool pressed)
        {
            
        }

        public void OnDrop(bool pressed)
        {
            if (!pressed) return;
            
            DeEquip();
        }
        
        private void EquipTool(Tool tool)
        {
            if (!tool) return;
            
            DeEquip();

            _equippedTool = tool;
            _equippedTool.transform.SetParent(mouseFollower);
            _equippedTool.transform.localPosition = Vector3.zero;
        }
        
        private void DeEquip()
        {
            if (!_equippedTool) return;
            
            _equippedTool.transform.SetParent(transform);
            _equippedTool.Respawn();
            _equippedTool = null;
        }
    }
}