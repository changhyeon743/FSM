using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlimeState {
    IDLE = 0,
    PATROL
}

public class SlimeFSManager : MonoBehaviour {
    public SlimeState currentState;
    public SlimeState startState;

    public CharacterController cc;
    public float moveSpeed;
    public float rotateSpeed;
    public float fallSpeed;

    Dictionary<SlimeState, SlimeFSMState> states = new Dictionary<SlimeState, SlimeFSMState>();

    public Animation anim;

	// Use this for initialization
	void Start () {
        states.Add(SlimeState.IDLE, GetComponent<SlimeFSMState>());
        states.Add(SlimeState.PATROL, GetComponent<SlimePATROL>());
        
        anim = GetComponentInChildren<Animation>();
        cc = GetComponent<CharacterController>();
        SetState(startState);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetState(SlimeState newState)
    {
        foreach (SlimeFSMState fsm in states.Values)
        {
            fsm.enabled = false;
        }

        states[newState].enabled = true;
        states[newState].beginState();
        currentState = newState;
    }
}
