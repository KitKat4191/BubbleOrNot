
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class FollowMouse : MonoBehaviour
    {
        private Camera _mainCamera;
        
        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Vector3 pos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            transform.position = pos;
        }
    }
}