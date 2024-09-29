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
            // 旋转 右手旋转
            {
                Vector2 rotateAxis = ctx.inputXRIAction.XRIRightHandLocomotion.Turn.ReadValue<Vector2>();
                ctx.rightHandl.rotateAxis = rotateAxis;
            }

        }
        public Vector2 GetMoveAxis() {
            return ctx.leftHandl.moveAxis;
        }

        public Vector2 GetRotateAxis() {
            return ctx.rightHandl.rotateAxis;
        }

    }
}