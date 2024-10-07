using System;
using UnityEngine;


namespace VR {


    public class RoleEntity : MonoBehaviour {

        [SerializeField] public Transform handtransform;

        [SerializeField] public GameObject leftHandDevice;

        [SerializeField] public GameObject rightHandDevice;



        public int id;

        public float moveSpeed;

        public float rotateSpeed;
        public RoleInputComponent InputComponent;



        public void Ctor() {
            InputComponent = new RoleInputComponent();

            moveSpeed = 5.5f;
            rotateSpeed = 100;

        }

        public void SetLeftHandDevicePos(Vector3 pos) {
            leftHandDevice.transform.position = pos;
        }

        public void SetRightHandDevicePos(Vector3 pos) {
            rightHandDevice.transform.position = pos;
        }

        public Vector3 GetHandPos() {
            return handtransform.position;
        }

        public Vector3 GetHandForward() {
            return handtransform.forward;
        }

        public void SetPos(Vector3 pos) {
            transform.position += pos;
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}
