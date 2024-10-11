using System;
using UnityEngine;



namespace VR {


    public static class Plane_Business {
        public static void Enter(GameContext ctx) {

            RoleEntity role = ctx.Role_GetOwner();

            // 位置归为原来的位置
            role.transform.position = new Vector3(0, 0, 0);

            //隐藏手
            role.SetActive();


            Vector3 pos = role.headtransform.position + new Vector3(0, 0, 2);
            PlaneEntity plane = PlaneDomain.Spawn(ctx, pos);
            ctx.gameEntity.planeOwnerID = plane.id;

            ctx.gameEntity.gameState = GameState.GameControllerPlane;
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

            RoleEntity owner = ctx.Role_GetOwner();
            if (owner.roleState == RoleState.Idle) {
                RoleDomain.SetHandPosition(ctx, owner);
                RoleDomain.SetHandRotate(ctx, owner);

                RoleDomain.Raycast(ctx, owner);
            } else if (owner.roleState == RoleState.Move) {
                RoleDomain.Move(ctx, owner, dt);
                RoleDomain.RoleHeadRotate(ctx, owner, dt);
                RoleDomain.SetHandPosition(ctx, owner);
                RoleDomain.SetHandRotate(ctx, owner);
                RoleDomain.Raycast(ctx, owner);

            }

            PlaneEntity plane = ctx.Plane_GetOwner();
            PlaneDomain.Move(ctx, plane, dt);


        }


        static void LateTick(GameContext ctx, float dt) {
            RoleEntity owner = ctx.Role_GetOwner();
            // 相机跟谁
            Vector2 offset = new Vector2(0, 0);
            ctx.cameraCore.Tick(owner.GetHandPos(), offset, 0, owner.GetHandForward(), dt);
        }



    }
}