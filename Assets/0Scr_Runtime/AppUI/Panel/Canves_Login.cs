using System;
using UnityEngine;
using UnityEngine.UI;


namespace VR {
    public class Canvas_Login : MonoBehaviour {

        [SerializeField] public Image Button;


        public void Ctor() {

        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void SetColor(Color color) {
            Button.color = color;
        }
    }
}