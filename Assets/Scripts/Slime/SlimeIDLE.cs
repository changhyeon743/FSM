using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIDLE : SlimeFSMState {

    public override void beginState()
    {
        base.beginState();
        manager.anim.CrossFade("SL_Idle");
        Invoke("Move",3.0f);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Move() {
        manager.SetState(SlimeState.PATROL);
   }
}
