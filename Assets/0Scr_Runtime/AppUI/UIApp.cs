using System;
using UnityEngine;



namespace VR {

    public class UIApp {

        public Canvas_Login canvas_Login;

        public UIApp() {
        }

        public  void Canvas_Login_Open(GameContext ctx) {
            Canvas_Login panel = ctx.uiApp.canvas_Login;
            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetLogin();
                if (prefab == null) {
                    Debug.LogError("UIApp.Canvas_Login_Open: prefab is null");
                    return;
                }

                GameObject go = GameObject.Instantiate(prefab);
                panel = go.GetComponent<Canvas_Login>();
                panel.Ctor();
            }

            panel.Show();

        }

    }
}