using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDEAD : SlimeFSMState {

    public override void beginState()
    {
        base.beginState();
        manager.playerCC.gameObject.GetComponent<PlayerFSManager>().SetState(PlayerState.IDLE);
        Destroy(gameObject, 5);

    }

}
