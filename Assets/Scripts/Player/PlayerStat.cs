using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    public float moveSpeed;
    public float fallSpeed;
    public float rotateSpeed;
    public float attackRange;

    public float attackRate;
    public float hp;
    public float currentHp;

    public PlayerFSManager manager;

    private void Awake()
    {
        manager = GetComponent<PlayerFSManager>();
    }

	// Use this for initialization
	void Start () {
        currentHp = hp;
	}

    void ApplyDamage(float amount)
    {
        currentHp -= amount;
        Debug.Log("[" + name + "] took damage: " + amount);
        if (currentHp <= 0)
        {
            manager.Dead();
        }
    }
}
