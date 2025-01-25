
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
    
    public abstract class Prop : MonoBehaviour
    {
        public abstract void OnToolUsed(ToolType toolType);
    }
}