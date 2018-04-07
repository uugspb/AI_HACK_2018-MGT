using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkableFactory : MonoBehaviour {

    public List<Sinkable> sinkables;

    public Sinkable GetSinkableByID(int id)
    {
        return sinkables[id];
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
