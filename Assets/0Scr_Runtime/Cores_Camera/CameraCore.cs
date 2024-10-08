using System;
using UnityEngine;

using VR.CameraInterval;


namespace VR {
    public class CameraCore {
        public CameraCoreContext ctx;

        public CameraCore() {
            ctx = new CameraCoreContext();
        }

        public void Inject(Camera camera) {
            ctx.Inject(camera);
        }

        public void Tick(Vector3 follow_targetPos, Vector2 follow_Offset, float follow_distance, Vector3 face, float dt) {
            // 只是简单的赋值
            CameraVirtualEntity virtualEntity = ctx.virtualEntity;
            virtualEntity.tagetPos = follow_targetPos;
            virtualEntity.offset = follow_Offset;
            virtualEntity.distance = follow_distance;


            // 相机跟随
            CameraFollow(follow_targetPos, follow_Offset, follow_distance, face);

        }

        public void CameraFollow(Vector3 follow_targetPos, Vector2 follow_Offset, float follow_distance, Vector3 face) {
            Camera maincam = ctx.camera;
            maincam.transform.position = follow_targetPos + new Vector3(follow_Offset.x, follow_Offset.y, -follow_distance);
            // face 等于头head的forward
            maincam.transform.forward = face;
        }

        public Camera GetCamera(){
            return ctx.camera;
        }
    }
}