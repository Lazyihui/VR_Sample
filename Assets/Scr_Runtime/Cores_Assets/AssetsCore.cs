using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;
using VR.AssetsInternal;


namespace VR {

    public class AssetsCore {
        AssetsContext ctx;



        public AssetsCore() {
            ctx = new AssetsContext();
        }


        public async Task LoadAll() {
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                // TODO:"Entity"
                labelReference.labelString = AssetLabelConst.Entity;
                var handle = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);

                var all = await handle.Task;
                foreach (var item in all) {
                    ctx.entityPrefabs.Add(item.name, item);
                }

                ctx.entityHandle = handle;

            }
        }

        public void UnloadAll() {
            if (ctx.entityHandle.IsValid()) {
                Addressables.Release(ctx.entityHandle);
            }

        }

        public GameObject Entity_GetRole() {
            ctx.entityPrefabs.TryGetValue("Entity_Role", out GameObject role);
            return role;
        }
    }
}

