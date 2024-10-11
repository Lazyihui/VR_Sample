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

            ctx.planeRepo.Add(entity);
            return entity;

        }
    }
}


