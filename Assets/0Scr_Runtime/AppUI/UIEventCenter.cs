using System;
using UnityEngine;


namespace VR {


    public class UIEventCenter {

        public Action OnStartBtnClickHandle;

        public void OnStartBtnClickHandleInvoke() {
            if(OnStartBtnClickHandle != null) {
                OnStartBtnClickHandle.Invoke();
            }
        }

    }
}