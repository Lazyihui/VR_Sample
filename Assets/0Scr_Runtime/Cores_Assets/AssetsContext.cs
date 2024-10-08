using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace VR.AssetsInternal {


    public class AssetsContext {

        public Dictionary<string, GameObject> entityPrefabs;

        public Dictionary<string, GameObject> panelPrefabs;

        public AsyncOperationHandle entityHandle;

        public AsyncOperationHandle panelHandle;
        public AssetsContext() {
            entityPrefabs = new Dictionary<string, GameObject>();
            panelPrefabs = new Dictionary<string, GameObject>();
        }


    }



}