using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Sinkable {

    public TrapConfig config;
    private CircleCollider2D triggerCollider;

	// Use this for initialization
	void Start () {
        triggerCollider = GetComponent<CircleCollider2D>();
        triggerCollider.enabled = false;
	}

    public override void Rise()
    {
        base.Rise();
        triggerCollider.enabled = false;
    }

    public override void Stay()
    {
        base.Stay();
        Debug.Log("TrapStay");
        triggerCollider.enabled = true;
    }
}
