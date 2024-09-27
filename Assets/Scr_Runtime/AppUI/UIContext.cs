using System;
using UnityEngine;


namespace VR.UIAppInterval {


    public class UIContext {
        public Panel_Login panel_Login;

        public UIEventCenter uiEventCenter;

        public UIContext() {
            uiEventCenter = new UIEventCenter();
        }
    }
}