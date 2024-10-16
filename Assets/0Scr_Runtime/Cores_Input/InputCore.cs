using System;
using UnityEngine;
using VR.InputInterval;

namespace VR {

    public class InputCore {

        public InputCoreContext ctx;

        public InputCore() {
            ctx = new InputCoreContext();
        }


        public void Tick(float dt, Camera camera, GameContext gameContext) {



            // 移动 左手移动 控制面板（相当于摇杆）
            {
                // XRILeftHandLocomotion.Move 这个是得到移动的方向 [-1,1] 
                Vector2 leftmoveAxis = ctx.inputXRIAction.XRILeftHandLocomotion.Move.ReadValue<Vector2>();
                ctx.leftHand.moveAxis = leftmoveAxis;

                Vector2 RightmoveAxis = ctx.inputXRIAction.XRIRightHandLocomotion.Move.ReadValue<Vector2>();
                ctx.rightHand.moveAxis = RightmoveAxis;
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
            // 得到扳机的位置

            {

                // float leftHandTrigger = ctx.inputXRIAction.XRILeftHandInteraction.UIPress.ReadValue<float>();
                // ctx.leftHand.triggerValue = leftHandTrigger;
                // if (leftHandTrigger > 0.5f) {
                //     Debug.Log("leftHandTrigger"+leftHandTrigger);
                //     gameContext.gameEntity.isTriggerPress = true;
                // } else {
                //     gameContext.gameEntity.isTriggerPress = false;
                // }

                // float rightHandTrigger = ctx.inputXRIAction.XRIRightHandInteraction.UIPress.ReadValue<float>();
                // ctx.rightHand.triggerValue = rightHandTrigger;
                // if (rightHandTrigger > 0.5f) {
                //     gameContext.gameEntity.isTriggerPress = true;
                // } else {
                //     gameContext.gameEntity.isTriggerPress = false;
                // }

                float leftHandTrigger = ctx.inputXRIAction.XRILeftHandInteraction.Activate.ReadValue<float>();
                ctx.leftHand.triggerValue = leftHandTrigger;

                if (leftHandTrigger > 0.5f) {
                    gameContext.gameEntity.isTriggerPress = true;
                } else {
                    gameContext.gameEntity.isTriggerPress = false;
                }


                float rightHandTrigger = ctx.inputXRIAction.XRILeftHandInteraction.Activate.ReadValue<float>();
                ctx.rightHand.triggerValue = rightHandTrigger;
                if (rightHandTrigger > 0.5f) {
                    gameContext.gameEntity.isTriggerPress = true;
                } else {
                    gameContext.gameEntity.isTriggerPress = false;
                }

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

        public Vector2 GetRightMoveAxis() {
            return ctx.rightHand.moveAxis;
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