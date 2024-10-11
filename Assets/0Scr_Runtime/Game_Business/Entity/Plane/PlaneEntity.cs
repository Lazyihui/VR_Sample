using System;
using UnityEngine;


namespace VR {
    public class PlaneEntity : MonoBehaviour {

        public int id;

        public float moveSpeed;
        public void Ctor() {
            moveSpeed = 5.5f;
        }

        public void TearDown() {
            GameObject.Destroy(gameObject);
        }

        public void SetPos(Vector3 pos) {
            this.transform.position = pos;
        }

        public void SetRotate() { }
    }
}