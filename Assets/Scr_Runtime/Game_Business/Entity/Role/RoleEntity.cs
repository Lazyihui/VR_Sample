using System;
using UnityEngine;


namespace VR {


    public class RoleEntity : MonoBehaviour {
        public int id;

        public float moveSpeed;

        public float rotateSpeed;
        public RoleInputComponent InputComponent;

        public void Ctor() {
            InputComponent = new RoleInputComponent();

            moveSpeed = 5.5f;
            rotateSpeed = 100;
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}
