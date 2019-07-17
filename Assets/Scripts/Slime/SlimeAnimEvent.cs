using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimEvent : MonoBehaviour {
    public SlimeFSManager manager;
    private void Awake()
    {
        manager = GetComponentInParent<SlimeFSManager>();
    }

    void AttackHitCheck()
    {
       // manager.playerCC.gameObject.SetActive(false);
        manager.AttackCheck();
       // manager.AttackCheck();
    }
}
