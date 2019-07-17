using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCHASE : SlimeFSMState {

    //public Transform target;

    public override void beginState()
    {
        base.beginState();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (manager.playerCC != null)
        {
            if (!SRUtil.Detect(manager.sight, 1, manager.playerCC))
            {
                manager.SetState(SlimeState.IDLE);

            }

            SRUtil.SRMove(manager.cc, manager.transform, manager.playerCC.transform.position, manager.stat.moveSpeed, manager.stat.rotateSpeed, manager.stat.fallSpeed);

            Vector3 diff = manager.playerCC.transform.position - transform.position;
            diff.y = 0;
            if (diff.sqrMagnitude < manager.stat.attackRange * manager.stat.attackRange)
            {
                manager.SetState(SlimeState.ATTACK);
                return;
            }
        }
        
	}
}
