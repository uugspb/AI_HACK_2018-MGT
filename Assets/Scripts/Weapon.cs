using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Sinkable {

    public WeaponConfig config;
    private BoxCollider2D triggerCollider;

    public bool isActiveOnFall;
    
	// Use this for initialization
	void Start () {
        triggerCollider = GetComponent<BoxCollider2D>();
	    if(isActiveOnFall)
            triggerCollider.enabled = true;
	    else
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
