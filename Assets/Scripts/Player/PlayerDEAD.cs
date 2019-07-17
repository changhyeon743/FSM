using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDEAD : PlayerFSMState {

    public override void BeginState()
    {
        base.BeginState();
        Destroy(gameObject, 5);

    }

}
