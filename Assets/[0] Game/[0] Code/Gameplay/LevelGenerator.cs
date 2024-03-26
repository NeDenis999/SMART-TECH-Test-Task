using UnityEngine;
using Zenject;

namespace Game
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField]
        private Enemy _enemyPrefab;

        [SerializeField]
        private Transform _spawnPoint;
        
        private GameData _gameData;
        private DiContainer _container;

        [Inject]
        public void Construct(GameData gameData, DiContainer container)
        {
            _gameData = gameData;
            _container = container;
        }
        
        public void Generate()
        {
            _gameData.EnemyCount.Value = 0;
            
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    var positionY = transform.position.y + y;
                    var positionX = transform.position.x + x - 2;
                    
                    var enemy = _enemyPrefab.Create();
                    _container.Inject(enemy);
                    enemy.transform.SetParent(_spawnPoint);
                    enemy.transform.position = new Vector3(positionX, positionY);

                    _gameData.EnemyCount.Value += 1;
                }
            }
        }
    }
}