using System;
using UnityEngine;


namespace VR {


    public static class HandDomain {
        public static HandEntity HandSpawn(GameContext ctx, Transform spawnPos, int typeID, Vector3 pos) {
            GameObject prefab = ctx.assetsCore.Entity_GetHand();
            if (prefab == null) {
                Debug.LogError("HandEntity prefab is null");
                return null;
            }

            GameObject go = GameObject.Instantiate(prefab, spawnPos);
            HandEntity entity = go.GetComponent<HandEntity>();

            entity.Ctor();

            entity.typeID = typeID;
            entity.id = ctx.gameEntity.handRecoredID++;

            Debug.Log("HandDomain pos"+pos);
            entity.SetPosition(pos);

            ctx.handRepo.Add(entity);

            return entity;
        }

        public static void UnSpawn(GameContext ctx, HandEntity entity) {
            ctx.handRepo.Remove(entity);
            entity.TearDown();
        }

        public static void SetHandPos(GameContext ctx, HandEntity entity) {
            Vector3 headPos = ctx.cameraCore.GetCamera().transform.position;
            if (entity.typeID == HandConst.HandType_Left) {

                entity.SetPosition(ctx.inputCore.GetLeftHandPos());
            } else if (entity.typeID == HandConst.HandType_Right) {
                
                entity.SetPosition(ctx.inputCore.GetRightHandPos());
            }

        }


    }
}