using System;
using UnityEngine;



namespace VR {

    public class GameEntity {


        public GameState gameState;
        public int roleOwnerID;

        public int handRecoredID;

        public int particleRecoredID;

        public float restTime;

        public float enterTimer;

        public bool isRightTouchLoginButton;

        public bool isLeftTouchLoginButton;

        public bool isTriggerPress;

        public int particleColliderID;

        public bool particleUnSpawn;

        // plane
        public int planeOwnerID;
        public GameEntity() {
            roleOwnerID = 0;
            handRecoredID = 0;
            particleRecoredID = 5;
            restTime = 0;
            enterTimer = 3;

            particleUnSpawn = false;
            planeOwnerID = 0;

            gameState = GameState.Login;

        }


    }
}