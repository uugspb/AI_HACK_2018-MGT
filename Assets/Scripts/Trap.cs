using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Dieble {

    public TrapConfig config;

    private float currentLiveTime;

	// Use this for initialization
	void Start () {
        currentLiveTime = config.liveTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentLiveTime < 0)
        {
            Die();
        }

        currentLiveTime -= Time.deltaTime;
	}
}
