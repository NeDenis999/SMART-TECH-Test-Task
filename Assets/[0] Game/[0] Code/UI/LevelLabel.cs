using TMPro;
using UnityEngine;
using Zenject;

namespace Game
{
    public class LevelLabel : MonoBehaviour
    {
        private GameData _gameData;
        
        [Inject]
        public void Construct(GameData gameData)
        {
            _gameData = gameData;
        }
        
        private void Start()
        {
            Upgrade(_gameData.Level);
        }

        public void Upgrade(int value)
        {
            GetComponent<TMP_Text>().text = "Level " + value;
        }
    }
}