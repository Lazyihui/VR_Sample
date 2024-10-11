using System;
using UnityEngine;


namespace VR {


    public class UIEventCenter {

        public Action OnStartBtnClickHandle;

        public void OnStartBtnClickHandleInvoke() {
            if (OnStartBtnClickHandle != null) {
                OnStartBtnClickHandle.Invoke();
            }
        }

        public Action OnBtn_AClickHandle;

        public void OnBtn_AClickHandleInvoke() {
            if (OnBtn_AClickHandle != null) {
                OnBtn_AClickHandle.Invoke();
            }
        }

    }
}