using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvent : MonoBehaviour {
    public PlayerFSManager manager;
    private void Awake() {
        manager = GetComponentInParent<PlayerFSManager>();
    }

    void AttackHitCheck() {
        manager.AttackCheck();
    }
}
