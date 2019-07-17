using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCHASE : PlayerFSMState {

    public override void BeginState()
    {
        base.BeginState();
        manager.marker.gameObject.SetActive(false);
        manager.attackMarker.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        SRUtil.SRMove(manager.cc, manager.transform, manager.target.position, manager.stat.moveSpeed, manager.stat.rotateSpeed, manager.stat.fallSpeed);



        Vector3 diff = manager.target.position - transform.position;
        diff.y = 0;
        if (diff.sqrMagnitude < manager.stat.attackRange * manager.stat.attackRange)
        {
            manager.SetState(PlayerState.ATTACK);
            return;
        }
	}
}
