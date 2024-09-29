using System;
using UnityEngine;


namespace VR.InputInterval {

    public class InputCoreContext {

        public InputEntity rightHandl;

        public InputEntity leftHandl;

        public InputEntity head;

        public InputXRIAction inputXRIAction;

        public InputCoreContext() {
            inputXRIAction = new InputXRIAction();
            inputXRIAction.Enable();

            leftHandl = new InputEntity();
            leftHandl.typeID = HandConst.HandType_Left;

            rightHandl = new InputEntity();
            rightHandl.typeID = HandConst.HandType_Right;

            head = new InputEntity();

        }

    }
}