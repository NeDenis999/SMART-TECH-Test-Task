using System.Collections;
using UnityEngine;

namespace Game
{
    public class EnemyShot : MonoBehaviour
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
            if (other.TryGetComponent(out Character character))
            {
                EventBus.Lose?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}