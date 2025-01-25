
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
    
    public abstract class Prop
    {
        public abstract void OnToolUsed(ToolType toolType);
    }
}