using System;
using UnityEngine;



namespace VR {


    public static class Plane_Business {
        public static void Enter(GameContext ctx) {

            PlaneEntity plane = PlaneDomain.Spawn(ctx, new Vector3(0, 0, 0));
            ctx.gameEntity.planeOwnerID = plane.id;

        }



        public static void Tick(GameContext ctx, float dt) {

            GameEntity game = ctx.gameEntity;

            // ProcessInput
            PreTick(ctx, dt);
            // DoLogic
            ref float restTime = ref game.restTime;

            restTime += dt;

            const float FIX_INTERVAL = 0.01f;

            if (restTime < FIX_INTERVAL) {
                FixTick(ctx, restTime);
                restTime = 0;
            } else {
                while (restTime >= FIX_INTERVAL) {
                    FixTick(ctx, FIX_INTERVAL);
                    restTime -= FIX_INTERVAL;
                }
            }

            LateTick(ctx, dt);


        }

        static void PreTick(GameContext ctx, float dt) {
            InputCore input = ctx.inputCore;

            input.Tick(dt, ctx.cameraCore.GetCamera(), ctx);

            // 赋值给角色
            RoleEntity owner = ctx.Role_GetOwner();

            RoleInputComponent InputComponent = owner.InputComponent;
            InputComponent.moveAxis = input.GetLeftMoveAxis();

            InputComponent.headrotate = input.GetHeadRotate();

        }

        static void FixTick(GameContext ctx, float dt) {


        }


        static void LateTick(GameContext ctx, float dt) {

        }



    }
}