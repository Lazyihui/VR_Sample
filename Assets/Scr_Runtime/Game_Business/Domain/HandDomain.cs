using System;
using UnityEngine;


namespace VR {


    public static class HandDomain {
        public static HandEntity HandSpawn(GameContext ctx, Vector3 position, int typeID) {
            GameObject prefab = ctx.assetsCore.Entity_GetHand();
            if (prefab == null) {
                Debug.LogError("HandEntity prefab is null");
                return null;
            }

            GameObject go = GameObject.Instantiate(prefab, position, Quaternion.identity);
            HandEntity entity = go.GetComponent<HandEntity>();

            entity.Ctor();

            entity.typeID = typeID;
            entity.id = ctx.gameEntity.handRecoredID++;

            ctx.handRepo.Add(entity);

            return entity;
        }

        public static void UnSpawn(GameContext ctx, HandEntity entity) {
            ctx.handRepo.Remove(entity);
            entity.TearDown();
        }

        public static void SetHandPos(GameContext ctx, HandEntity entity) {
            if (entity.typeID == HandConst.HandType_Left) {
                entity.SetPosition(ctx.inputCore.GetLeftHandPos());
            } else if (entity.typeID == HandConst.HandType_Right) {
                entity.SetPosition(ctx.inputCore.GetRightHandPos());
            }

        }


    }
}