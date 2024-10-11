using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VR {



    public class Main : MonoBehaviour {


        GameContext ctx;

        bool isTearDown = false;
        bool isInit = false;

        void Awake() {

            ctx = new GameContext();



            Camera camera = Camera.main;
            ctx.Inject(camera);

            Action action = async () => {
                await ctx.assetsCore.LoadAll();
                isInit = true;

                //== Enter==

                Game_Business.Enter(ctx);

            };

            action.Invoke();

            Binding(ctx);



        }

        void Binding(GameContext ctx) {

            var uiEventCenter = ctx.uiApp.uiEventCenter;

            uiEventCenter.OnStartBtnClickHandle = () => {

                Game_Business.EnterGame(ctx);

                ParticleDomain.Spawn(ctx);
            };

            uiEventCenter.OnBtn_AClickHandle = () => {
                ctx.uiApp.Canvas_A_Close(ctx);
                // 进入下一个场景
                Plane_Business.Enter(ctx);

            };

        }

        void Update() {
            if (!isInit) {
                return;
            }
            float dt = Time.deltaTime;

            if (ctx.gameEntity.gameState == GameState.Login) {
                Game_Business.Tick(ctx, dt);
            } else if (ctx.gameEntity.gameState == GameState.GameControllerPlane) {
                Plane_Business.Tick(ctx, dt);
            }


        }
        void OnApplictionQuit() {
            TearDown();
        }

        void OnDestory() {
            TearDown();
        }

        void TearDown() {
            // 确保只运行一次
            if (isTearDown) {
                return;
            }
            isTearDown = true;

            ctx.assetsCore.UnloadAll();
        }
    }
}
