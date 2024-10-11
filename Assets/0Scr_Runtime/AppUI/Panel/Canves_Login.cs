using System;
using UnityEngine;
using UnityEngine.UI;


namespace VR {
    public class Canvas_Login : MonoBehaviour {

        [SerializeField] public Image bg_Btn;

        [SerializeField] public Button StartBtn;

        public Action OnStartBtnClick;

        public void Ctor() {
            StartBtn.onClick.AddListener(() => {
                OnStartBtnClick?.Invoke();
            });
        }

      
        public void Show() {
            gameObject.SetActive(true);
        }
        public void TearDown() {
            GameObject.Destroy(gameObject);
        }
    }
}