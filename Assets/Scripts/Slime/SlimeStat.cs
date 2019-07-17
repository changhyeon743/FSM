using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStat : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;
    public float fallSpeed;

    public float attackRange;
    public float attackRate;

    public float hp;
    public float currentHp;

    public SlimeFSManager manager;

    private void Awake()
    {
        manager = GetComponentInParent<SlimeFSManager>();
    }

	void Start () {
        currentHp = hp;
	}
	

    public void ApplyDamage(float amount)
    {
        currentHp -= amount;
        //manager.SetState(SlimeState.ATTACK);
        Debug.Log("[" + name + "] took damage: " + amount);
        if (currentHp <= 0)
        {
            manager.Dead();
        }
    }
}
