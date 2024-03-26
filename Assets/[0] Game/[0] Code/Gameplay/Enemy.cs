using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game
{
    public class Enemy : MonoBehaviour, IFactory<Enemy>
    {
        [SerializeField]
        private EnemyShot[] _shots;

        [SerializeField]
        private float _shotInterval;

        [SerializeField]
        private Transform _shotPoint;
        
        private GameData _gameData;

        [Inject]
        public void Construct(GameData gameData)
        {
            _gameData = gameData;
        }

        public void Shot()
        {
            Instantiate(_shots[Random.Range(0, _shots.Length)], _shotPoint.position, Quaternion.identity);
        }

        public void Death()
        {
            _gameData.Score.Value += 100;
            _gameData.EnemyCount.Value -= 1;
            Destroy(gameObject);
        }

        public Enemy Create()
        {
            var enemy = Instantiate(this);
            return enemy;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Ground ground))
            {
                EventBus.Lose?.Invoke();
            }
        }
    }
}