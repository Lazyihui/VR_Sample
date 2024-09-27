using System;
using UnityEngine;
using VR.UIAppInterval;


namespace VR {

    public class UIApp {

        public UIContext ctx;

        public UIEventCenter uiEventCenter => ctx.uiEventCenter;
        public UIApp() {
            ctx = new UIContext();
        }

    }
}