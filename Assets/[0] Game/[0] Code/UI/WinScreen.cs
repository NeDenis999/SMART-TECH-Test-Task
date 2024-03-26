using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
    public class WinScreen : MonoBehaviour
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
            StartCoroutine(AwaitOpen());
            print("Win");
        }
        
        private IEnumerator AwaitOpen()
        {
            yield return new WaitForSeconds(2);
            _gameData.Level += 1;
            SceneManager.LoadScene(0);
        }
    }
}