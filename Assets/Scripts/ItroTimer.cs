using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItroTimer : MonoBehaviour {

    public GameObject dialog;
    public float itroTime;
    private float currentTime;
    private bool isEnded = false;
    private float currentDialogTimeForStart;
    public float dialogTimeStart;
    private float currentTimeDialog;
    private float dialogTime;
    

	// Use this for initialization
	void Start () {
        currentTime = itroTime;
        currentDialogTimeForStart = dialogTimeStart;

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

        if(currentDialogTimeForStart > 0)
        {
            currentDialogTimeForStart -= Time.deltaTime;
        }
        else
        {
            if (!dialog.activeSelf)
            {
                dialog.SetActive(true);
                currentTimeDialog = dialogTime;
            }
        }

	}
}
