
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class PropsFlusher : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        public void FlushProps()
        {
            Prop[] props = _target.GetComponentsInChildren<Prop>();

            for (int i = props.Length - 1; i >= 0; i--)
            {
                if (!props[i].IsFlushable) continue;
                Destroy(props[i].gameObject);
            }
        }
    }
}