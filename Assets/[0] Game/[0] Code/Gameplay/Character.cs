using System.Collections;
using UnityEngine;
using Zenject;
using UniRx;

namespace Game
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private int _step;

        [SerializeField]
        private float _shotInterval;

        [SerializeField]
        private GameObject _shotPrefab;

        [SerializeField]
        private Transform _shotPoint;

        [SerializeField]
        private float _maxX, _minX;

        [SerializeField] 
        private float _minY;
        
        [SerializeField] 
        private float _maxY;
        
        [SerializeField]
        private float _speedY;
        
        [Inject]
        private InputManager _inputManager;

        private IEnumerator Start()
        {
            _inputManager.Horizontal.Subscribe(MoveX);
            
            while (true)
            {
                yield return new WaitForSeconds(_shotInterval);
                Instantiate(_shotPrefab, _shotPoint.position, Quaternion.identity);
            }
        }

        private void Update()
        {
            if (_inputManager.Vertical.Value != 0)
            {
                MoveY(_inputManager.Vertical.Value);
            }
        }

        private void MoveY(float vertical)
        {
            var nextPos = transform.position + new Vector3(0, vertical * _speedY * Time.deltaTime);
            transform.position = nextPos.SetY(Mathf.Clamp(nextPos.y, _minY, _maxY));
        }

        private void MoveX(int horizontal)
        {
            var nextPos = transform.position + new Vector3(horizontal * _step, 0);
            transform.position = nextPos.SetX(Mathf.Clamp(nextPos.x, _minX, _maxX));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                Destroy(gameObject);
                EventBus.Lose?.Invoke();
            }
        }

        public void Stop()
        {
            StopAllCoroutines();
            _inputManager.Horizontal.Dispose();
            enabled = false;
        }
    }
}