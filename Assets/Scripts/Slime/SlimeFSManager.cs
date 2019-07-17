using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlimeState {
    IDLE = 0,
    PATROL,
    CHASE,
    ATTACK,
    DEAD
}

public class SlimeFSManager : MonoBehaviour {
    public SlimeState currentState;
    public SlimeState startState;

    public CharacterController cc;

    public SlimeStat stat;

    Dictionary<SlimeState, SlimeFSMState> states = new Dictionary<SlimeState, SlimeFSMState>();

    public Animator anim;

    public Camera sight;
    public CharacterController playerCC;


	// Use this for initialization
	void Awake () {
        states.Add(SlimeState.IDLE, GetComponent<SlimeIDLE>());
        states.Add(SlimeState.PATROL, GetComponent<SlimePATROL>());
        states.Add(SlimeState.CHASE, GetComponent<SlimeCHASE>());
        states.Add(SlimeState.ATTACK, GetComponent<SlimeATTACK>());
        states.Add(SlimeState.DEAD, GetComponent<SlimeDEAD>());
        
        anim = GetComponentInChildren<Animator>();
        cc = GetComponent<CharacterController>();
        
        sight = GetComponentInChildren<Camera>();
        playerCC = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        stat = GetComponent<SlimeStat>();
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
            //Debug.Log(fsm);
        }

        states[newState].enabled = true;
        states[newState].beginState();
        currentState = newState;
        anim.SetInteger("CurrentState", (int)currentState);

    }

    private void OnDrawGizmos()
    {
        if (sight != null)
        {
            Gizmos.color = Color.blue;
            Matrix4x4 temp = Gizmos.matrix;
            Gizmos.matrix = Matrix4x4.TRS(
                sight.transform.position,
                sight.transform.rotation,
                Vector3.one
                );
            Gizmos.DrawFrustum(sight.transform.position, sight.fieldOfView, sight.farClipPlane, sight.nearClipPlane,1);

            Gizmos.matrix = temp;
        }
    }

    public void AttackCheck()
    {
        Debug.Log("Attack");
        playerCC.gameObject.SendMessage("ApplyDamage",stat.attackRate);
        //playerCC.gameObject.GetComponent<PlayerFSManager>().SetState(PlayerState.DEAD);
    }

    public void Dead()
    {
        cc.enabled = false;
        SetState(SlimeState.DEAD);
        //playerCC.GetComponent<PlayerFSManager>().SetState(PlayerState.DEAD);
    }
}
