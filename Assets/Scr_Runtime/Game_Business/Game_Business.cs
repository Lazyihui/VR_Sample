using System;
using UnityEngine;


namespace VR {
    public static class Game_Business {
        public static void Enter(GameContext ctx) {

            RoleEntity role = RoleDomain.Spawn(ctx, 1, new Vector3(0, 0, 0));
            ctx.gameEntity.roleOwnerID = role.id;
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

            input.Tick(dt);

            // 赋值给角色
            RoleEntity owner = ctx.Role_GetOwner();

            RoleInputComponent InputComponent = owner.InputComponent;
            InputComponent.moveAxis = input.GetMoveAxis();
            InputComponent.rotateAxis = input.GetRotateAxis();
        }

        static void FixTick(GameContext ctx, float dt) {

            RoleEntity owner = ctx.Role_GetOwner();
            RoleDomain.Move(ctx, owner, dt);
            RoleDomain.RotateFace(ctx, owner, dt);

        }

        static void LateTick(GameContext ctx, float dt) {
            RoleEntity owner = ctx.Role_GetOwner();

            Vector2 offset = new Vector2(0, 0);

            ctx.cameraCore.Tick(owner.transform.position, offset, 0, owner.transform.forward, dt);
        }

    }
}