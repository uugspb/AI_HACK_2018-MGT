using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour {

    public static ParticlePlayer instance;
    public static ParticleSystem particleSystem;

	// Use this for initialization
	void Start () {
        instance = this;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SetParticleSystem(ParticleSystem particleSystem)
    {
        particleSystem.transform.parent = instance.transform;
        particleSystem.transform.position = new Vector3(particleSystem.transform.position.x,
                                                        particleSystem.transform.position.y,
                                                        0);
        particleSystem.Play();
    }

}
