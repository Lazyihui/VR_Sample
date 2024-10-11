using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace VR {
    public static class Game_Business {
        public static void Enter(GameContext ctx) {

            ctx.uiApp.Canvas_Login_Open(ctx);

            RoleEntity role = RoleDomain.Spawn(ctx, 1, new Vector3(0, 0, 0));
            ctx.gameEntity.roleOwnerID = role.id;

        }

        public static void EnterGame(GameContext ctx) {

            ctx.uiApp.Canvas_Login_Close(ctx);

            RoleEntity role = ctx.Role_GetOwner();
            role.roleState = RoleState.Move;

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

            // gameDomain

            if (ctx.gameEntity.isRightTouchLoginButton || ctx.gameEntity.isLeftTouchLoginButton) {
                if (ctx.gameEntity.particleUnSpawn) {
                    return;
                }
                //按下
                if (ctx.gameEntity.isTriggerPress) {
                    // 1.销毁
                    ctx.particleRepo.TryGet(ctx.gameEntity.particleColliderID, out ParticleEnity particle);
                    ParticleDomain.UnSpawn(ctx, particle);
                    ctx.gameEntity.particleUnSpawn = true;
                    // 2.进入下一个场景
                    ctx.uiApp.Canvas_A_Open(ctx);
                }

            } else if (!ctx.gameEntity.isLeftTouchLoginButton || !ctx.gameEntity.isRightTouchLoginButton) {

            }

            // particleDomain

            int parLen = ctx.particleRepo.TakeAll(out ParticleEnity[] particles);

            for (int i = 0; i < parLen; i++) {
                ParticleEnity particle = particles[i];
                ParticleDomain.ParticleTick(ctx, particle, dt);
            }
        }


        static void LateTick(GameContext ctx, float dt) {
            RoleEntity owner = ctx.Role_GetOwner();

            Vector2 offset = new Vector2(0, 0);
            ctx.cameraCore.Tick(owner.GetHandPos(), offset, 0, owner.GetHandForward(), dt);
        }

    }
}