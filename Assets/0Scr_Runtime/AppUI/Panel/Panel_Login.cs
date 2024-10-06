using System;
using UnityEngine;
using UnityEngine.UI;


namespace VR {


    public class Panel_Login : MonoBehaviour {


        [SerializeField] Button startBtn;

        [SerializeField] Text txt;
        
        public Action OnStartHandel;

        public void Ctor() {

            startBtn.onClick.AddListener(() => {
                OnStartHandel.Invoke();
            });

        }

    }

}