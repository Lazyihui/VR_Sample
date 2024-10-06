using System;
using UnityEngine;
using VR;


namespace VR.CameraInterval {

    public class CameraCoreContext {

        public Camera camera;

        public CameraVirtualEntity virtualEntity;

        public CameraCoreContext() {
            virtualEntity = new CameraVirtualEntity();
        }

        public void Inject(Camera camera) {
            this.camera = camera;
        }

    }
}