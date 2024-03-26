using System.Collections;
using UnityEngine;

namespace Game
{
    public class Shot : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }

        private void Update()
        {
            transform.position = transform.position.AddY(Time.deltaTime * _speed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.Death();
                Destroy(gameObject);
            }

            if (other.TryGetComponent(out EnemyShot enemyShot))
            {
                Destroy(enemyShot.gameObject);
                Destroy(gameObject);
            }
        }
    }
}