using System;
using UnityEngine;


namespace VR {
    public class PlaneEntity : MonoBehaviour {

        public int id;

        public void Ctor() {

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