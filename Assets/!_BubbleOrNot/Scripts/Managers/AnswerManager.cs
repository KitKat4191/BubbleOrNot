
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class AnswerManager : MonoBehaviour
    {
        [SerializeField] private PropManager propManager;

        private int _score;
        
        public void IsBubble()
        {
            AnsweredCorrectly(propManager.CurrentProp.IsBubble);
            propManager.SpawnNextProp();
        }

        public void IsNotBubble()
        {
            AnsweredCorrectly(!propManager.CurrentProp.IsBubble);
            propManager.SpawnNextProp();
        }

        private void AnsweredCorrectly(bool wasCorrect)
        {
            if (wasCorrect) _score++;
        }
    }
}