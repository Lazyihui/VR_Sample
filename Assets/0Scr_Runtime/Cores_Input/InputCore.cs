using System;
using UnityEngine;
using VR.InputInterval;

namespace VR {

    public class InputCore {

        public InputCoreContext ctx;

        public InputCore() {
            ctx = new InputCoreContext();
        }


        public void Tick(float dt,Camera camera) {

            // float LeftHand = ctx.inputXRIAction.XRILeftHandInteraction.ActivateValue.ReadValue<float>();

            // float RightHand = ctx.inputXRIAction.XRIRightHandInteraction.ActivateValue.ReadValue<float>();

            // if (LeftHand > 0.5f) {
            //     Debug.Log("LeftHand");
            // }

            // if (RightHand > 0.5f) {
            //     Debug.Log("RightHand");
            // }

            // 移动 左手移动
            {
                Vector2 moveAxis = ctx.inputXRIAction.XRILeftHandLocomotion.Move.ReadValue<Vector2>();
                ctx.leftHand.moveAxis = moveAxis;

            }
            // 旋转 右手旋转 不对 应该是头部旋转
            // {
            //     Vector2 rotateAxis = ctx.inputXRIAction.XRIRightHandLocomotion.Turn.ReadValue<Vector2>();
            //     ctx.rightHandl.rotateAxis = rotateAxis;
            // }

            // 旋转 头部旋转
            {
                // Quaternion quat = camera.transform.rotation;
                // ctx.head.rotate = quat;
                
                Quaternion quat = ctx.inputXRIAction.XRIHead.Rotation.ReadValue<Quaternion>();

                Vector3 fwd = quat * Vector3.forward;

                ctx.head.rotate = quat;
            }
            // 位置 头部位置
            {
                Vector3 headPos = ctx.inputXRIAction.XRIHead.Position.ReadValue<Vector3>();
                 
                ctx.head.position = headPos;
                Debug.Log("headPos:" + headPos);
            }
            {

            }
            // 得到左右手的位置
            {
                Vector3 leftHandPos = ctx.inputXRIAction.XRILeftHand.Position.ReadValue<Vector3>();
                ctx.leftHand.position = leftHandPos;

                Vector3 rightHandPos = ctx.inputXRIAction.XRIRightHand.Position.ReadValue<Vector3>();
                ctx.rightHand.position = rightHandPos;
            }


        }
        public Vector2 GetLeftMoveAxis() {
            return ctx.leftHand.moveAxis;
        }

        public Vector2 GetRightRotateAxis() {
            // 目前是00
            return ctx.rightHand.rotateAxis;
        }

        public Quaternion GetHeadRotate() {
            return ctx.head.rotate;
        }

        public Vector3 GetLeftHandPos() {
            return ctx.leftHand.position;
        }

        public Vector3 GetRightHandPos() {
            return ctx.rightHand.position;
        }

        public Vector3 GetHeadPos() {
            Debug.Log("GetHeadPos:" + ctx.head.position);
            return ctx.head.position;
        }

    }
}