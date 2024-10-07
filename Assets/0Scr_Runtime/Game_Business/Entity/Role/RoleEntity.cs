using System;
using UnityEngine;


namespace VR {


    public class RoleEntity : MonoBehaviour {

        [SerializeField] Transform Handtransform;


        public int id;

        public float moveSpeed;

        public float rotateSpeed;
        public RoleInputComponent InputComponent;



        public void Ctor() {
            InputComponent = new RoleInputComponent();

            moveSpeed = 5.5f;
            rotateSpeed = 100;

        }

        public Vector3 GetHandPos() {
            return Handtransform.position;
        }






        public void SetPos(Vector3 pos) {
            transform.position += pos;
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}
