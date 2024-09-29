using System;
using UnityEngine;
using VR.InputInterval;

namespace VR {

    public class InputCore {

        public InputCoreContext ctx;


        public InputCore() {
            ctx = new InputCoreContext();
        }


        public void Tick(float dt) {

            float LeftHand = ctx.inputXRIAction.XRILeftHandInteraction.ActivateValue.ReadValue<float>();

            float RightHand = ctx.inputXRIAction.XRIRightHandInteraction.ActivateValue.ReadValue<float>();

            if (LeftHand > 0.5f) {
                Debug.Log("LeftHand");
            }

            if (RightHand > 0.5f) {
                Debug.Log("RightHand");
            }

            // 移动 左手移动
            {
                Vector2 moveAxis = ctx.inputXRIAction.XRILeftHandLocomotion.Move.ReadValue<Vector2>();
                ctx.leftHandl.moveAxis = moveAxis;

            }
            // 旋转 右手旋转 不对 应该是头部旋转
            // {
            //     Vector2 rotateAxis = ctx.inputXRIAction.XRIRightHandLocomotion.Turn.ReadValue<Vector2>();
            //     ctx.rightHandl.rotateAxis = rotateAxis;
            // }

            // 旋转 头部旋转
            {
                Quaternion quat = ctx.inputXRIAction.XRIHead.Rotation.ReadValue<Quaternion>();

                Vector3 fwd = quat * Vector3.forward;

                ctx.head.rotate = quat;
            }
            // 得到左右手的位置
            {
                Vector3 leftHandPos = ctx.inputXRIAction.XRILeftHand.Position.ReadValue<Vector3>();
                ctx.leftHandl.position = leftHandPos;
             
                Vector3 rightHandPos = ctx.inputXRIAction.XRIRightHand.Position.ReadValue<Vector3>();
                ctx.rightHandl.position = rightHandPos;

            }
        }
        public Vector2 GetLeftMoveAxis() {
            return ctx.leftHandl.moveAxis;
        }

        public Vector2 GetRightRotateAxis() {
            return ctx.rightHandl.rotateAxis;
        }

        public Quaternion GetHeadRotate() {
            return ctx.head.rotate;
        }

        public Vector3 GetLeftHandPos() {
            return ctx.leftHandl.position;
        }

        public Vector3 GetRightHandPos() {
            return ctx.rightHandl.position;
        }

    }
}