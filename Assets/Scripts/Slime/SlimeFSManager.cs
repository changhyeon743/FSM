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

    public Animator anim;

	// Use this for initialization
	void Awake () {
        states.Add(SlimeState.IDLE, GetComponent<SlimeIDLE>());
        states.Add(SlimeState.PATROL, GetComponent<SlimePATROL>());
        
        anim = GetComponentInChildren<Animator>();
        cc = GetComponent<CharacterController>();
        
	}

    void Start() {
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
            Debug.Log(fsm);
        }

        states[newState].enabled = true;
        states[newState].beginState();
        currentState = newState;
        anim.SetInteger("CurrentState", (int)currentState);
    }
}
