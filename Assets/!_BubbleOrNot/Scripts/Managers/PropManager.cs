
using System.Collections;
using UnityEngine;
using VRRefAssist;

using BubbleOrNot.Utils;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class PropManager : MonoBehaviour
    {
        [SerializeField] private bool doInfiniteMode;
        
        [Header("References")]
        [SerializeField] private Transform propDispenser;
        [SerializeField] private Animator pipeAnimator;
        [SerializeField] private SpriteRenderer currentPropIcon;
        
        [Space]
        [SerializeField] private float pipeAnimationDuration = 1f;

        [Header("Audio")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private float minPitchVariation;
        [SerializeField] private float maxPitchVariation;

        [Header("Spawn Settings")]
        [SerializeField] private Vector2 spawnVelocity;
        [SerializeField] private float minSpawnRotationSpeed;
        [SerializeField] private float maxSpawnRotationSpeed;
        
        
        [SerializeField, HideInInspector, GetComponentsInChildren] private Prop[] props;

        
        private int _currentPropIndex = -1;

        
        public Prop CurrentProp => props[_currentPropIndex];
        public int PropCount => doInfiniteMode ? int.MaxValue : props.Length;
        

        private void Awake()
        {
            props.Shuffle();
        }

        private void Start()
        {
            SpawnNextProp();
        }
        
        public void SpawnNextProp()
        {
            pipeAnimator.SetTrigger("Dispense");
            StartCoroutine(SpawnNextDelayed(pipeAnimationDuration));
        }
        
        private IEnumerator SpawnNextDelayed(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);

            if (!TrySpawnProp()) yield break;
            
            PlaySpawnSound();
            UpdatePropIcon();
        }

        private void PlaySpawnSound()
        {
            audioSource.Stop();
            audioSource.pitch = Random.Range(1 - minPitchVariation, 1 + maxPitchVariation);
            audioSource.Play();
        }

        private bool TrySpawnProp()
        {
            _currentPropIndex++;

            if (_currentPropIndex >= props.Length)
            {
                Debug.Log("No more props!");
                if (doInfiniteMode)
                {
                    _currentPropIndex = 0;
                    props.Shuffle();
                }
                else return false;
            }
            
            Prop newProp = Instantiate(props[_currentPropIndex], propDispenser.position, propDispenser.rotation, propDispenser);
            newProp.gameObject.SetActive(true);
            
            var rb = newProp.GetComponent<Rigidbody2D>();
            rb.velocity = spawnVelocity;
            rb.angularVelocity = Random.Range(minSpawnRotationSpeed, maxSpawnRotationSpeed);
            
            return true;
        }

        private void UpdatePropIcon()
        {
            currentPropIcon.sprite = props[_currentPropIndex].DisplaySprite;
        }
    }
}