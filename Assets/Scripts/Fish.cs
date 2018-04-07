using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    [SerializeField]
    private FishConfig FishConfig;

    public static Vector3 target;
    // Update is called once per frame

    void Update () {
        Vector3.Lerp(this.transform.position, target, FishConfig.speed * Time.deltaTime);	
	}


}
