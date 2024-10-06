using System;
using UnityEngine;



namespace VR {

    public class HandEntity : MonoBehaviour {

        public int id;

        public int typeID;
        
        public void Ctor() {

        }

        public void SetPosition(Vector3 position) {
            transform.position = position;
            Debug.Log("HandEntity SetPosition"+position);
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}