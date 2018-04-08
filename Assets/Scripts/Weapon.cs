using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Sinkable {

    public WeaponConfig config;
    private BoxCollider2D triggerCollider;

    public bool isSharpe = true;
    public bool isActiveOnFall;
    public bool mustExploseBeforeRise = false;
    public bool explosionNeedToStay = false;
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

    public bool IsSharpe()
    {
        return isSharpe;
    }

    protected override void Explosion()
    {
        base.Explosion();
        //GetComponent<ParticleSystem>().Play();
        if (particleSystem != null)
        {
            ParticlePlayer.SetParticleSystem(particleSystem);
            Debug.Log(particleSystem.isPlaying);
        }
        else
        {
            Debug.Log("ParticleSystem is null");
        }
        Debug.Log("Explosion");
        RaycastHit2D[] raycasts = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.up);
        foreach (RaycastHit2D raycast in raycasts)
        {
            if (raycast.collider.tag == "Fish")
            {
                Debug.Log("Fish Explosion");
                Fish fish = raycast.collider.gameObject.GetComponent<Fish>();
                if (explosionNeedToStay && fish.IsFishMove())
                    break;
                fish.Hit(config.hitPower);
            }
        }
    }
}
