
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("BubbleOrNot/Tool")]
    public class Tool : MonoBehaviour
    {
        [SerializeField] private ToolType toolType;
        
        
        private Vector3 _spawnPosition;

        private void Awake()
        {
            _spawnPosition = transform.position;
        }


        public void Respawn()
        {
            transform.position = _spawnPosition;
        }
        
        public void OnUse()
        {
            
        }
    }
}