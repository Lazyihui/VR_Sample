using System;
using UnityEngine;


namespace VR {
    public class RoleInputComponent {

        public Vector2 moveAxis;

        public Vector2 rotateAxis;

        public Quaternion headrotate;


        public RoleInputComponent() {
            moveAxis = Vector2.zero;
            rotateAxis = Vector2.zero;
            headrotate = Quaternion.identity;

        }
    }
}