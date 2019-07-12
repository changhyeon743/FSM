using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFSMState : MonoBehaviour {

    protected SlimeFSManager manager;

    public virtual void beginState() {

    }

    void Awake() {
        manager = GetComponent<SlimeFSManager>();
    }
}
