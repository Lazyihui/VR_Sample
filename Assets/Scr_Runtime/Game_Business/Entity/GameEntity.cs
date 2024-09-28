using System;
using UnityEngine;



namespace VR {

    public class GameEntity {

        public int roleOwnerID;

        public float restTime;

        public float enterTimer;

        public GameEntity() {
            roleOwnerID = 0;
            restTime = 0;

            enterTimer = 3;
        }
    }
}