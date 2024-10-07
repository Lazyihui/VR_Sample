using System;

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


        // public static void 

        public static void Move(GameContext ctx, RoleEntity role, float dt) {
            RoleInputComponent inputComponent = role.InputComponent;
            float moveSpeed = role.moveSpeed;
            Vector3 moveDir = new Vector3(inputComponent.moveAxis.x, 0, inputComponent.moveAxis.y);
            moveDir.Normalize();
            // 这一句让物体始终向物体的前方移动
            moveDir = role.handtransform.transform.rotation * moveDir;
            // 

            moveDir = moveDir * moveSpeed * dt;
            role.transform.position += moveDir;

        }

        public static void RotateHead(GameContext ctx, RoleEntity role, float dt) {
            RoleInputComponent inputComponent = role.InputComponent;
            Vector3 rotateDir = inputComponent.headrotate * Vector3.forward;
            role.transform.rotation = Quaternion.LookRotation(rotateDir);
        }

        public static void RoleHeadRotate(GameContext ctx, RoleEntity role , float dt){
            RoleInputComponent inputComponent = role.InputComponent;
            Vector3 rotateDir = inputComponent.headrotate * Vector3.forward;

            role.handtransform.rotation = Quaternion.LookRotation(rotateDir);
        }


    }


}