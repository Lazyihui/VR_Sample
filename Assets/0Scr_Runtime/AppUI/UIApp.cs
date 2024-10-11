using System;
using UnityEngine;



namespace VR {

    public class UIApp {

        public Canvas_Login canvas_Login;

        public Canvas_A canvas_A;

        public UIEventCenter uiEventCenter;
        public UIApp() {
            uiEventCenter = new UIEventCenter();
        }

        public void Canvas_Login_Open(GameContext ctx) {
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
                panel.OnStartBtnClick = () => {
                    uiEventCenter.OnStartBtnClickHandleInvoke();
                };
                ctx.uiApp.canvas_Login = panel;

            }
            panel.Show();
        }


        public void Canvas_Login_Close(GameContext ctx) {
            Canvas_Login panel = ctx.uiApp.canvas_Login;
            if (panel == null) {
                return;
            }
            panel.TearDown();
        }

        public void Canvas_A_Open(GameContext ctx) {
            Canvas_A panel = ctx.uiApp.canvas_A;
            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetA();
                if (prefab == null) {
                    Debug.LogError("UIApp.Canvas_A_Open: prefab is null");
                    return;
                }
                GameObject go = GameObject.Instantiate(prefab);
                panel = go.GetComponent<Canvas_A>();
                panel.Ctor();
                panel.OnBtn_AClick = () => {
                    uiEventCenter.OnBtn_AClickHandleInvoke();
                };

                ctx.uiApp.canvas_A = panel;

            }
            panel.Show();
        }


        public void Canvas_A_Close(GameContext ctx) {
            Canvas_A panel = ctx.uiApp.canvas_A;
            if(panel == null) {
                return;
            }
            panel.TearDown();

        }


    }
}