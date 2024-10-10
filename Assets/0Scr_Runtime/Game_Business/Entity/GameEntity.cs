using System;
using UnityEngine;



namespace VR {

    public class GameEntity {

        public int roleOwnerID;

        public int handRecoredID;

        public int particleRecoredID;

        public float restTime;

        public float enterTimer;

        public bool isRightTouchLoginButton;

        public bool isLeftTouchLoginButton;

        public bool isTriggerPress;

        public int particleColliderID;



        public GameEntity() {
            roleOwnerID = 0;
            handRecoredID = 0;
            particleRecoredID = 0;
            restTime = 0;
            enterTimer = 3;

        }

        public ParticleEnity GetCollider_Particle(GameContext ctx,int id) {
            ctx.particleRepo.TryGet(id, out ParticleEnity particle);
            return particle;

        }
    }
}