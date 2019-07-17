using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIDLE : SlimeFSMState {

    public override void beginState(){
        base.beginState();
        //manager.anim.CrossFade("SL_Idle");
        Invoke("Move",2.0f);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (SRUtil.Detect(manager.sight,1,manager.playerCC)) {
            manager.SetState(SlimeState.CHASE);
        }
	}

    void Move() {
        manager.SetState(SlimeState.PATROL);
   }
}