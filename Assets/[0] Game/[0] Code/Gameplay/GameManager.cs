using UniRx;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        private GameData _gameData;
        private WinScreen _winScreen;
        private LoseScreen _loseScreen;
        private LevelGenerator _levelGenerator;
        private Character _character;

        [Inject]
        public void Construct(WinScreen winScreen, LoseScreen loseScreen, LevelGenerator levelGenerator,
            GameData gameData, Character character)
        {
            _winScreen = winScreen;
            _loseScreen = loseScreen;
            _levelGenerator = levelGenerator;
            _gameData = gameData;
            _character = character;
        }
        
        private void Awake()
        {
            _gameData.Score = new IntReactiveProperty();
            _gameData.EnemyCount = new IntReactiveProperty();
            _gameData.Score.Value = 0;
            _gameData.IsPause = false;
            
            EventBus.Lose = null;
        }
        
        private void Start()
        {
            _levelGenerator.Generate();
            
            _gameData.EnemyCount
                .Where(value => value <= 0)
                .Subscribe(x => _winScreen.Open());

            EventBus.Lose += () =>
            {
                _loseScreen.Open();
                _character.Stop();
            };
        }

        [ContextMenu("Уничтожить всех врагов")]
        public void DestroyAllEnemies()
        {
            foreach (var enemy in FindObjectsOfType<Enemy>())
            {
                enemy.Death();
            }
        }
        
        [ContextMenu("Проиграть")]
        public void Lose()
        {
            EventBus.Lose?.Invoke();
        }
    }
}