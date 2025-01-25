
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    public abstract class Clickable : MonoBehaviour
    {
        public abstract void OnClick(bool pressed);
    }
}