
using System.Collections;
using UnityEngine;
using VRRefAssist;

using BubbleOrNot.Utils;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class PropManager : MonoBehaviour
    {
        [SerializeField] private Transform propDispenser;
        [SerializeField] private Animator pipeAnimator;
        [SerializeField] private float pipeAnimationDuration = 1f;

        [Header("Spawn Settings")]
        [SerializeField] private Vector2 spawnVelocity;
        [SerializeField] private float minSpawnRotationSpeed;
        [SerializeField] private float maxSpawnRotationSpeed;
        
        
        [SerializeField, HideInInspector, GetComponentsInChildren] private Prop[] props;

        
        private int _currentPropIndex;
        

        private void Awake()
        {
            props.Shuffle();
        }
        
        
        public void SpawnNextProp()
        {
            pipeAnimator.SetTrigger("Dispense");
            StartCoroutine(SpawnNextDelayed(pipeAnimationDuration));
        }
        
        private IEnumerator SpawnNextDelayed(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            
            Prop newProp = Instantiate(props[_currentPropIndex], propDispenser.position, propDispenser.rotation, propDispenser);
            
            var rb = newProp.GetComponent<Rigidbody2D>();
            rb.velocity = spawnVelocity;
            rb.angularVelocity = Random.Range(minSpawnRotationSpeed, maxSpawnRotationSpeed);
            
            _currentPropIndex++;

            if (_currentPropIndex >= props.Length)
            {
                Debug.Log("No more props!");
                _currentPropIndex = 0;
                props.Shuffle();
            }
        }
    }
}