
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    public enum ToolType
    {
        Alien,
        Hammer,
        Needle,
        Taser,
    }
    
    public class Prop : MonoBehaviour
    {
        public void OnToolUsed(ToolType toolType)
        {
            
        }
    }
}