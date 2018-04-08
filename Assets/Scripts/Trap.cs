using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Sinkable {

    public TrapConfig config;
    private CircleCollider2D triggerCollider;
    private Animator animator;

	// Use this for initialization
	void Start () {
        triggerCollider = GetComponent<CircleCollider2D>();
        triggerCollider.enabled = false;
        animator = GetComponent<Animator>();
        animator.enabled = false;
	}

    public override void Rise()
    {
        base.Rise();
        triggerCollider.enabled = false;
        if(animator != null)
            animator.enabled = false;
    }

    public override void Stay()
    {
        base.Stay();
        Debug.Log("TrapStay");
        triggerCollider.enabled = true;
        if (animator != null)
            animator.enabled = true;
    }
}
