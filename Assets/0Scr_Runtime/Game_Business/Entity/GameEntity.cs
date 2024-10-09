using System;
using UnityEngine;



namespace VR {

    public class GameEntity {

        public int roleOwnerID;

        public int handRecoredID;

        public float restTime;

        public float enterTimer;

        public bool isRightTouchLoginButton;

        public bool isLeftTouchLoginButton;

    

        public GameEntity() {
            roleOwnerID = 0;
            handRecoredID = 0;

            restTime = 0;
            enterTimer = 3;

        }
    }
}