using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRUN : PlayerFSMState {

    public override void BeginState() {
        base.BeginState();
        manager.anim.CrossFade("KK_Run_No");
        manager.marker.gameObject.SetActive(true);
        manager.attackMarker.gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        SRUtil.SRMove(manager.cc, manager.transform, manager.marker.position, manager.moveSpeed, manager.rotateSpeed, manager.fallSpeed);

        Vector3 diff = manager.marker.position - transform.position;
        diff.y = 0;
        if (diff.sqrMagnitude < 0.1f * 0.1f) {
            manager.SetState(PlayerState.IDLE);
            return;
        }
	}
}
