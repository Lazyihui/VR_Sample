using System;
using UnityEngine;



namespace VR {

    public class GameContext {

        public InputCore inputCore;

        public UIApp uiApp;

        public GameContext() {
            inputCore = new InputCore();
        }
    }
}