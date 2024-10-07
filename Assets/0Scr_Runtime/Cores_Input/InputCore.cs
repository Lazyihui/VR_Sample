using System;
using UnityEngine;
using VR.InputInterval;

namespace VR {

    public class InputCore {

        public InputCoreContext ctx;

        public InputCore() {
            ctx = new InputCoreContext();
        }


        public void Tick(float dt, Camera camera) {



            // 移动 左手移动 控制面板（相当于摇杆）
            {
                // XRILeftHandLocomotion.Move 这个是得到移动的方向 [-1,1] 
                Vector2 moveAxis = ctx.inputXRIAction.XRILeftHandLocomotion.Move.ReadValue<Vector2>();
                ctx.leftHand.moveAxis = moveAxis;
            }

            // 得到左右手相对于头的位置
            {
                // XRILeftHand.Position 得到的是相对于头部的位置
                Vector3 leftHandPos = ctx.inputXRIAction.XRILeftHand.Position.ReadValue<Vector3>();
                ctx.leftHand.relativeHeadPos = leftHandPos;

                Vector3 rightHandPos = ctx.inputXRIAction.XRIRightHand.Position.ReadValue<Vector3>();
                ctx.rightHand.relativeHeadPos = rightHandPos;
            }

            // 得到手的旋转
            {
                Quaternion leftHandRotate = ctx.inputXRIAction.XRILeftHand.Rotation.ReadValue<Quaternion>();
                ctx.leftHand.rotate = leftHandRotate;

                Quaternion rightHandRotate = ctx.inputXRIAction.XRIRightHand.Rotation.ReadValue<Quaternion>();
                ctx.rightHand.rotate = rightHandRotate;

            }
           


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

                ctx.head.relativeHeadPos = headPos;
            }



        }
       


        public Vector2 GetLeftMoveAxis() {
            return ctx.leftHand.moveAxis;
        }

        public Quaternion GetHeadRotate() {
            return ctx.head.rotate;
        }



        public Vector3 GetLeftHandPos() {
            return ctx.leftHand.relativeHeadPos;
        }

        public Vector3 GetRightHandPos() {
            return ctx.rightHand.relativeHeadPos;
        }

        public Quaternion GetLeftHandRotate() {
            return ctx.leftHand.rotate;
        }

        public Quaternion GetRightHandRotate() {
            return ctx.rightHand.rotate;
        }        

    }
}