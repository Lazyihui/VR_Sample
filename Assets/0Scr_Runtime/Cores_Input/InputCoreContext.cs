using System;
using UnityEngine;


namespace VR.InputInterval {

    public class InputCoreContext {

        public InputEntity rightHand;

        public InputEntity leftHand;

        public InputEntity head;

        public InputXRIAction inputXRIAction;

        public InputCoreContext() {
            inputXRIAction = new InputXRIAction();
            inputXRIAction.Enable();

            leftHand = new InputEntity();
            leftHand.id = 0;
            leftHand.typeID = HandConst.HandType_Left;

            rightHand = new InputEntity();
            rightHand.id = 1;
            rightHand.typeID = HandConst.HandType_Right;

            head = new InputEntity();

        }

    }
}