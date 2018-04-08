using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Sinkable {

    public WeaponConfig config;
    private BoxCollider2D triggerCollider;

    public bool isActiveOnFall;
    public bool mustExploseBeforeRise = false;
    public ParticleSystem particleSystem;

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
        if (mustExploseBeforeRise)
        {
            Explosion();
        }
        base.Rise();
        triggerCollider.enabled = false;
    }

    public override void Stay()
    {
        base.Stay();
        triggerCollider.enabled = true;
    }

    protected override void Explosion()
    {
        base.Explosion();
        if(particleSystem != null)
            particleSystem.Play();
        Debug.Log("Explosion");
        RaycastHit2D[] raycasts = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.up);
        foreach (RaycastHit2D raycast in raycasts)
        {
            if (raycast.collider.tag == "Fish")
            {
                Debug.Log("Fish Explosion");
                Fish fish = raycast.collider.gameObject.GetComponent<Fish>();
                fish.Hit(config.hitPower);
            }
        }
    }
}
