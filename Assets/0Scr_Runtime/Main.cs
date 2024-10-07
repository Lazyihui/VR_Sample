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


        }


        void Update() {
            if (!isInit) {
                return;
            }
            float dt = Time.deltaTime;

            Game_Business.Tick(ctx, dt);

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
