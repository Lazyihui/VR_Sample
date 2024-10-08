using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR {

    public static class RoleDomain {


        public static RoleEntity Spawn(GameContext ctx, int typeID, Vector3 pos) {
            GameObject prefab = ctx.assetsCore.Entity_GetRole();
            if (prefab == null) {
                Debug.LogError("RoleEntity prefab is null");
                return null;
            }

            GameObject go = GameObject.Instantiate(prefab, pos, Quaternion.identity);
            RoleEntity entity = go.GetComponent<RoleEntity>();

            entity.Ctor();

            ctx.roleRepo.Add(entity);

            return entity;
        }


        public static void UnSpawn(GameContext ctx, RoleEntity role) {
            ctx.roleRepo.Remove(role);
            role.TearDown();
        }

        public static void Raycast(GameContext ctx, RoleEntity role) {

            // 左手
            {
                //1.射线的起点
                Vector3 rayOriginLeft = role.GetLeftHandPos();
                Ray rayLeft = new Ray(rayOriginLeft, role.leftHandDevice.transform.forward);

                // RaycastHit leftHit
                bool leftHit = Physics.Raycast(rayLeft, out RaycastHit hitInfo, 9999, 1 << 7);

                Debug.DrawRay(rayOriginLeft, role.leftHandDevice.transform.forward * 9999, Color.green);
                // if (leftHit) {
                //     // Debug.DrawLine(rayOriginLeft, hitInfo.point, Color.red);
                //     Debug.Log("hitInfo.point: " + hitInfo.point);
                //     ctx.gameEntity.isTouchLoginButton = true;
                // } else {
                //     ctx.gameEntity.isTouchLoginButton = false;
                // }
            }
            // 右手
            {
                Vector3 rayOriginRight = role.GetRightHandPos();
                Ray rayRight = new Ray(rayOriginRight, role.rightHandDevice.transform.forward);

                // RaycastHit rightHit
                bool rightHit = Physics.Raycast(rayRight, out RaycastHit hitInfo, 99999, 1 << 7);
                Debug.DrawRay(rayOriginRight, role.rightHandDevice.transform.forward * 99999, Color.red);


                if (rightHit) {
                    // Debug.DrawLine(rayOriginRight, hitInfo.point, Color.red);
                    Debug.DrawLine(rayOriginRight, hitInfo.point, Color.green);
                    Debug.Log("hitInfo.point: " + hitInfo.point);
                    
                    ctx.gameEntity.isTouchLoginButton = true;
                } else {
                    ctx.gameEntity.isTouchLoginButton = false;
                }
            }

        }


        // 人物移动
        public static void Move(GameContext ctx, RoleEntity role, float dt) {
            RoleInputComponent inputComponent = role.InputComponent;
            float moveSpeed = role.moveSpeed;
            Vector3 moveDir = new Vector3(inputComponent.moveAxis.x, 0, inputComponent.moveAxis.y);
            moveDir.Normalize();
            // 这一句让物体始终向物体的前方移动 //向头的方向移动

            moveDir = role.headtransform.transform.rotation * moveDir;
            moveDir = moveDir * moveSpeed * dt;
            role.transform.position += moveDir;

        }
        // 头的旋转
        public static void RoleHeadRotate(GameContext ctx, RoleEntity role, float dt) {
            RoleInputComponent inputComponent = role.InputComponent;
            Vector3 rotateDir = inputComponent.headrotate * Vector3.forward;

            role.headtransform.rotation = Quaternion.LookRotation(rotateDir);
        }
        // 手的设备的移动
        public static void SetHandPosition(GameContext ctx, RoleEntity role) {
            role.SetLeftHandDevicePos(ctx.inputCore.GetLeftHandPos());
            role.SetRightHandDevicePos(ctx.inputCore.GetRightHandPos());
        }

        public static void SetHandRotate(GameContext ctx, RoleEntity role) {
            role.SetLeftHandDeviceRot(ctx.inputCore.GetLeftHandRotate());
            role.SetRightHandDeviceRot(ctx.inputCore.GetRightHandRotate());

        }
    }


}