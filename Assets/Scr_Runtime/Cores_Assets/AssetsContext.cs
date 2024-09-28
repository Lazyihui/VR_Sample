using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace VR.AssetsInternal {


    public class AssetsContext {

        public Dictionary<string, GameObject> entityPrefabs;

        public AsyncOperationHandle entityHandle;
        public AssetsContext() {
            entityPrefabs = new Dictionary<string, GameObject>();
        }


    }



}