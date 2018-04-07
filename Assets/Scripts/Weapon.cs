using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Sinkable {

    public WeaponConfig config;
    private BoxCollider2D triggerCollider;

	// Use this for initialization
	void Start () {
        triggerCollider = GetComponent<BoxCollider2D>();
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
        triggerCollider.enabled = true;
    }
}
