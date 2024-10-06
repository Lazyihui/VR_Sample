using System;
using UnityEngine;


namespace VR.CameraInterval {
    public class CameraVirtualEntity {


        public Vector3 tagetPos;

        public Vector2 offset;

        public float distance;


        public CameraVirtualEntity() {
            tagetPos = Vector3.zero;
            offset = Vector2.zero;
            distance = 0;
        }
    }
}