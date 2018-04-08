using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkableButton : Button {
    public int sinkableID;
    public SinkableConfig sinkableConfig;
    public bool isBlocked = true;

    private float remainTime = 0;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = grayColor;
    }
    
    protected override void OnMouseClicked()
    {

        if (!isBlocked)
        {
            base.OnMouseClicked();
            GameManager.SetPlayerSinkable(sinkableID);
        }
    }

    private void Update()
    {
        if (remainTime > 0)
        {
            remainTime -= Time.deltaTime;
        }
        else if(!click && !LevelManager.GetI().isStart)
        {
            isBlocked = false;
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void Block()
    {
        this.GetComponent<SpriteRenderer>().color = grayColor;
        isBlocked = true;
        remainTime = sinkableConfig.cooldown;
    }
}
