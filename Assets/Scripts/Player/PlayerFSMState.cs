﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSMState : MonoBehaviour {
    protected PlayerFSManager manager;

    public virtual void BeginState() {

    }
    
    private void Awake() {
        manager = GetComponent<PlayerFSManager>();
        
    }
}
