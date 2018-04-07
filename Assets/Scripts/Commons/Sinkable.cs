using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinkable : MonoBehaviour {
    public int sinkableID;
    public Vector2 sinkTarget;
    private bool isSinking = false;
    public SinkableConfig sinkableConfig;

    public void Sink()
    {
        isSinking = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isSinking && sinkTarget.y < transform.position.y)
        {
            Debug.Log("Sinking");
            transform.position = Vector3.MoveTowards(transform.position, sinkTarget, sinkableConfig.sinkSpeed * Time.deltaTime);
        }
	}
}
