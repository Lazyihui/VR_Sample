using System;
using UnityEngine;
using UnityEngine.UI;


namespace VR {


    public class Canvas_A : MonoBehaviour {
        [SerializeField] public Button btn_A;

        public Action OnBtn_AClick;
        public void Ctor() {

            btn_A.onClick.AddListener(() => {
                OnBtn_AClick?.Invoke();
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