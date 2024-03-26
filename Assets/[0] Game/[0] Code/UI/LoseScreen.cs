using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
    public class LoseScreen : MonoBehaviour
    {
        private GameData _gameData;
        
        [Inject]
        public void Construct(GameData gameData)
        {
            _gameData = gameData;
        }
        
        public void Open()
        {
            gameObject.SetActive(true);
            print("Lose");
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            _gameData.IsPause = true;
            _gameData.Score.Value = 0;
            _gameData.Level = 1;
            SceneManager.LoadScene(0);
        }
    }
}