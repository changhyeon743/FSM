﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIDLE : PlayerFSMState {
    public override void BeginState() {
        base.BeginState();
        manager.anim.CrossFade("KK_Idle");
        manager.marker.gameObject.SetActive(false);
        manager.attackMarker.gameObject.SetActive(false);
    }


	void Start () {
		
	}


	void Update () {
        //Debug.Log("IDLE");
	}
}