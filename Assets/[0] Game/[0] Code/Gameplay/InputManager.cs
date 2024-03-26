using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private PressButton _upButton, _downButton;

        [SerializeField]
        private Button _leftButton, _rightButton;

        public IntReactiveProperty Horizontal = new IntReactiveProperty();
        public IntReactiveProperty Vertical = new IntReactiveProperty();

        private void Awake()
        {
            _leftButton.onClick.AddListener(() => Horizontal.Value = -1);
            _rightButton.onClick.AddListener(() => Horizontal.Value = 1);
            
            _upButton.Press += () => Vertical.Value = 1;
            _upButton.PressUp += () => Vertical.Value = 0;
            
            _downButton.Press += () => Vertical.Value = -1;
            _downButton.PressUp += () => Vertical.Value = 0;
        }

        private void Update()
        {
            if ((int)Input.GetAxisRaw("Vertical") != Vertical.Value && !_upButton.Pressed && !_downButton.Pressed)
            {
                Vertical.Value = (int)Input.GetAxisRaw("Vertical");
            }
            
            if ((int)Input.GetAxisRaw("Horizontal") != Horizontal.Value)
            {
                Horizontal.Value = (int)Input.GetAxisRaw("Horizontal");
            }
        }
    }
}