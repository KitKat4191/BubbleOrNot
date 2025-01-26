
using TMPro;
using UnityEngine;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private PropManager propManager;
        
        [Space]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject loseScreen;
        [SerializeField] private GameObject winScreen;


        private int _answersSubmitted;
        private int _score;
        private int _maxScore;


        private void Start()
        {
            _score = 0;
            _answersSubmitted = 0;
            _maxScore = propManager.PropCount;
            UpdateScore();
        }
        
        
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
            _answersSubmitted++;
            if (wasCorrect) _score++;
            UpdateScore();
            if (_answersSubmitted >= _maxScore) OnAllAnswersSubmitted();
        }

        private void UpdateScore()
        {
            scoreText.text = $"You got {_score} / {_maxScore} correct!";
        }

        private void OnAllAnswersSubmitted()
        {
            gameOverScreen.SetActive(true);
            
            bool won = _score == _maxScore;
            
            winScreen.SetActive(won);
            loseScreen.SetActive(!won);
        }
    }
}