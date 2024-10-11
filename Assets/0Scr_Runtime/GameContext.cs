using System;
using UnityEngine;



namespace VR {

    public class GameContext {

        // 
        public GameEntity gameEntity;

        // core

        public InputCore inputCore;

        public CameraCore cameraCore;

        public AssetsCore assetsCore;

        // rope

        public RoleRepo roleRepo;

        public ParticleRepo particleRepo;

        public PlaneRepo planeRepo;

        public UIApp uiApp;

        // Inject


        public GameContext() {
            // 
            gameEntity = new GameEntity();

            // core
            inputCore = new InputCore();
            cameraCore = new CameraCore();
            assetsCore = new AssetsCore();
            // rope
            roleRepo = new RoleRepo();
            particleRepo = new ParticleRepo();
            planeRepo = new PlaneRepo();

            uiApp = new UIApp();

            // 
        }

        public void Inject(Camera camera) {
            cameraCore.Inject(camera);
        }

        public RoleEntity Role_GetOwner() {
            bool has = roleRepo.TryGet(gameEntity.roleOwnerID, out RoleEntity entity);
            if (!has) {
                Debug.LogError("GameContext.Role_GetOwner: roleOwnerID not found");
                return null;
            }
            return entity;
        }

        public PlaneEntity Plane_GetOwner() {
            bool has = planeRepo.TryGet(gameEntity.planeOwnerID, out PlaneEntity entity);
            if (!has) {
                Debug.LogError("GameContext.Plane_GetOwner: planeOwnerID not found");
                return null;
            }
            return entity;
        }
    }



}