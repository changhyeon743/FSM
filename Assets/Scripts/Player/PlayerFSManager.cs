using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    IDLE = 0,
    RUN,
    CHASE,
    ATTACK
}

public class PlayerFSManager : MonoBehaviour {
    //플레이어의 상태
    public PlayerState currentState;

    //시작할 때 초기화해줄 상태
    public PlayerState startState;
    public Transform marker;
    public Transform attackMarker;

    public CharacterController cc;
    public float moveSpeed;
    public float fallSpeed;
    public float rotateSpeed;
    public float attackRange;

    public Transform target;

    public LayerMask layerMask;
    
    Dictionary<PlayerState,PlayerFSMState> states = new Dictionary<PlayerState,PlayerFSMState>();

    public Animator anim;

    private void Awake() {
        Debug.Log("Awake");
        layerMask = (1 << 10) + (1 << 11);

        marker = GameObject.FindGameObjectWithTag("marker").transform;
        attackMarker = GameObject.FindGameObjectWithTag("attackMarker").transform;

        cc = GetComponent<CharacterController>();

        states.Add(PlayerState.IDLE, GetComponent<PlayerIDLE>());
        states.Add(PlayerState.RUN, GetComponent<PlayerRUN>());
        states.Add(PlayerState.CHASE, GetComponent<PlayerCHASE>());
        states.Add(PlayerState.ATTACK, GetComponent<PlayerATTACK>());

        anim = GetComponentInChildren<Animator>();

        Debug.Log("Awake done");
    }

	void Start () {
        SetState(startState);
	}

    public void SetState(PlayerState newState)
    {
        foreach (PlayerFSMState fsm in states.Values)
        {
            fsm.enabled = false;
        }

        currentState = newState;
        states[newState].enabled = true;
        states[newState].BeginState();
        anim.SetInteger("CurrentState", (int)currentState);
        
    }
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            //비트연산 : 1000000000
            //int layer = 1 << 10;

            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit, 1000, layerMask)) {
                if (hit.transform.gameObject.layer == 10) {
                    marker.position = hit.point;
                    SetState(PlayerState.RUN);
                }
                else if (hit.transform.gameObject.layer == 11) {
                    //CHASE
                    
                    target = hit.transform;
                    attackMarker.parent = target;
                    attackMarker.localPosition = Vector3.zero;
                    SetState(PlayerState.CHASE);
                }
                
            }
        }
	}
}
