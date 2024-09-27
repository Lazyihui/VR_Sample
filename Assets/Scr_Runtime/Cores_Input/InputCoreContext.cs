using System;
using UnityEngine;


namespace VR.InputInterval {

    public class InputCoreContext {

        public InputXRIAction inputXRIAction;

        public InputCoreContext() {
            inputXRIAction = new InputXRIAction();
            inputXRIAction.Enable();


        }

    }
}