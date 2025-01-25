
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class ToolManager : MonoBehaviour
    {
        private Tool _currentTool;

        
        public void OnClickedTool(Tool tool)
        {
            if (!tool) return;
            if (!_currentTool)
                _currentTool = tool;
        }

        public void OnClickedProp(Prop prop)
        {
            if (!prop) return;
            if (!_currentTool) return;
        }
    }
}