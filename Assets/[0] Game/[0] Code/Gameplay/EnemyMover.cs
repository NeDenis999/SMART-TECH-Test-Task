using System.Collections;
using UnityEngine;
using Zenject;

namespace Game
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField]
        private float _durationStep;

        private GameData _gameData;

        [Inject]
        private void Construct(GameData gameData)
        {
            _gameData = gameData;
        }
        
        private IEnumerator Start()
        {
            EventBus.Lose += () => StopAllCoroutines();
            
            for (int y = 0; y < 5; y++)
            {
                yield return new WaitForSeconds(_durationStep);
                
                yield return AwaitMoveRight(1);
                yield return AwaitMoveLeft(2);
                yield return AwaitMoveRight(1);
                yield return AwaitMoveDown();
            }

            if (_gameData.EnemyCount.Value > 0)
                EventBus.Lose?.Invoke();
        }

        private IEnumerator AwaitMoveDown()
        {
            yield return new WaitForSeconds(_durationStep);
            transform.position = transform.position.AddY(-1);
        }

        private IEnumerator AwaitMoveRight(int countStep)
        {
            for (int i = 0; i < countStep; i++)
            {
                transform.position = transform.position.AddX(1);
                yield return new WaitForSeconds(_durationStep);
            }
        }

        private IEnumerator AwaitMoveLeft(int countStep)
        {
            for (int i = 0; i < countStep; i++)
            {
                transform.position = transform.position.AddX(-1);
                yield return new WaitForSeconds(_durationStep);
            }
        }
    }
}