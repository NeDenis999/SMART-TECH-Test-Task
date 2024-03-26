using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class PressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool Pressed { get; set; }

        public Action Press;
        public Action PressUp { get; set; }


        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed = true;
            Press?.Invoke();
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            Pressed = false;
            PressUp?.Invoke();
        }
    }
}