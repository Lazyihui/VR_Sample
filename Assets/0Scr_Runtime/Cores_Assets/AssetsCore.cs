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

                labelReference.labelString = AssetLabelConst.Entity;
                var handle = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);

                var all = await handle.Task;
                foreach (var item in all) {
                    ctx.entityPrefabs.Add(item.name, item);
                }

                ctx.entityHandle = handle;

            }

            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = AssetLabelConst.Panel;
                var handle = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);

                var all = await handle.Task;
                foreach (var item in all) {
                    ctx.panelPrefabs.Add(item.name, item);
                }

                ctx.panelHandle = handle;

            }
        }

        public void UnloadAll() {
            if (ctx.entityHandle.IsValid()) {
                Addressables.Release(ctx.entityHandle);
            }
            if (ctx.panelHandle.IsValid()) {
                Addressables.Release(ctx.panelHandle);
            }

        }

        public GameObject Entity_GetRole() {
            ctx.entityPrefabs.TryGetValue("Entity_Role_test", out GameObject role);
            return role;
        }


        public GameObject Entity_GetHand() {
            ctx.entityPrefabs.TryGetValue("Entity_Hand", out GameObject hand);
            return hand;
        }

        public GameObject Panel_GetLogin() {

            ctx.panelPrefabs.TryGetValue("Canvas_test", out GameObject login);
            return login;
        }

        public GameObject Entity_Particle() {
            ctx.entityPrefabs.TryGetValue("Entity_Particle", out GameObject particle);
            return particle;
        }

    }
}

