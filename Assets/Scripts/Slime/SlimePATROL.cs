using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePATROL : SlimeFSMState {

    Vector3 goal;

    public override void beginState()
    {                                                                
        base.beginState();                                           
        manager.anim.CrossFade("SL_Walk");                           
        Vector3 origin = goal;                                       
        //goal = new Vector3(Random.Range(origin.x - 3.0f, origin.x + 3.0f), 0, Random.Range(origin.z - 3.0f, origin.z + 3.0f));
        goal = new Vector3(Random.Range( - 5.0f,  + 5.0f), 0, Random.Range(- 5.0f,  + 5.0f));

        

    }


    // Use this for initialization
    void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
        SRUtil.SRMove(manager.cc, manager.transform, goal, manager.moveSpeed, manager.rotateSpeed, manager.fallSpeed);

        Vector3 diff = goal - transform.position;
        diff.y = 0;
        if (diff.sqrMagnitude < 0.1f * 0.1f)
        {
            manager.SetState(SlimeState.IDLE);
            return;
        }
	}
}
