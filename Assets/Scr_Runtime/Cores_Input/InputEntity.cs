using System;
using UnityEngine;


namespace VR {
    public class InputEntity {
        public int id;

        public int typeID;

        public Vector3 position;
        
        public Vector2 moveAxis;

        public Vector2 rotateAxis;

        public Quaternion rotate;

        


        public InputEntity() {
            moveAxis = Vector2.zero;
            rotateAxis = Vector2.zero;
        }
    }
}