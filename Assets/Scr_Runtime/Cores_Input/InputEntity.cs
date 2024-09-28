using System;
using UnityEngine;


namespace VR {
    public class InputEntity {
        public int id;

        public Vector2 moveAxis;

        public Vector2 rotateAxis;


        public InputEntity() {
            moveAxis = Vector2.zero;
            rotateAxis = Vector2.zero;
        }
    }
}