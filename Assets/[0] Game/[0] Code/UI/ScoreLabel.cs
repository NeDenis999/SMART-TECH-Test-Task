using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ScoreLabel : MonoBehaviour
    {
        private GameData _gameData;

        [Inject]
        public void Construct(GameData gameData)
        {
            _gameData = gameData;
        }
        
        private void Start()
        {
            Upgrade(_gameData.Score.Value);
            _gameData.Score.Subscribe(Upgrade);
        }

        public void Upgrade(int score)
        {
            GetComponent<TMP_Text>().text = "Score: " + score;
        }
    }
}