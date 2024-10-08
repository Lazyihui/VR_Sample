using System;
using UnityEngine;


namespace VR {


    public class RoleEntity : MonoBehaviour {

        [SerializeField] public Transform headtransform;

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
            leftHandDevice.transform.localPosition = pos*0.1f + new Vector3(-0.5f, 1.2f, 0.85f);
        }


        public void SetRightHandDevicePos(Vector3 pos) {
            rightHandDevice.transform.localPosition = pos*0.1f + new Vector3(0.5f, 1.2f, 0.85f);
        }

        public void SetLeftHandDeviceRot(Quaternion rot) {
            leftHandDevice.transform.localRotation = rot;
        }

        public void SetRightHandDeviceRot(Quaternion rot) {
            rightHandDevice.transform.localRotation = rot;
        }
        
        public Vector3 GetLeftHandPos() {
            return leftHandDevice.transform.position;
        }

        public Vector3 GetRightHandPos() {
            return rightHandDevice.transform.position;
        }

        public Vector3 GetHandPos() {
            return headtransform.position;
        }

        public Vector3 GetHandForward() {
            return headtransform.forward;
        }



        public void SetPos(Vector3 pos) {
            transform.position += pos;
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}
