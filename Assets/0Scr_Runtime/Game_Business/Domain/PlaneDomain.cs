using System;
using UnityEngine;



namespace VR {


    public static class PlaneDomain {
        public static PlaneEntity Spawn(GameContext ctx, Vector3 pos) {
            GameObject prefab = ctx.assetsCore.Entity_Plane();
            if (prefab == null) {
                Debug.LogError("no");
                return null;
            }

            GameObject go = GameObject.Instantiate(prefab);
            PlaneEntity entity = go.GetComponent<PlaneEntity>();

            entity.Ctor();

            entity.SetPos(pos);

            ctx.planeRepo.Add(entity);
            return entity;

        }

        public static void UnSpawn(GameContext ctx, PlaneEntity plane) {
            ctx.planeRepo.Remove(plane);
            plane.TearDown();
        }

        public static void Move(GameContext ctx, PlaneEntity plane, float dt) {

            float moveSpeed = plane.moveSpeed;

            Vector2 moveAxis = ctx.inputCore.GetLeftMoveAxis();
            Vector3 moveDir = new Vector3(moveAxis.x, 0, moveAxis.y);
            moveDir.Normalize();

            // 这一句让物体始终向物体的前方移动 //向头的方向移动
            moveDir = plane.transform.rotation * moveDir;
            moveDir = moveDir * moveSpeed * dt;
            plane.transform.position += moveDir;

        }
    }
}


