using System;
using UnityEngine;


namespace VR {
    public class InputEntity {
        public int id;

        public int typeID;

        public Vector3 devicePos;

        public Vector3 relativeHeadPos;

        
        public Vector2 moveAxis;

        public Quaternion rotate;

        


        public InputEntity() {
            moveAxis = Vector2.zero;
            devicePos = Vector3.zero;
        }
    }
}