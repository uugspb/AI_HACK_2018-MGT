using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItroTimer : MonoBehaviour {

    public float itroTime;
    private float currentTime;
    private bool isEnded = false;

	// Use this for initialization
	void Start () {
        currentTime = itroTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else if(!isEnded)
        {
            isEnded = true;
            LevelManager.GetI().nextLevel();
            Destroy(this);
        }
	}
}
