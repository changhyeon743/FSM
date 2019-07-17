using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeATTACK : SlimeFSMState {

    public override void beginState()
    {
        base.beginState();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (manager.playerCC.gameObject != null)
        {
            Vector3 diff = manager.playerCC.transform.position - transform.position;
            diff.y = 0;
            if (diff.sqrMagnitude > manager.stat.attackRange * manager.stat.attackRange)
            {
                manager.SetState(SlimeState.PATROL);
                return;
            }
        }
        
	}
}
