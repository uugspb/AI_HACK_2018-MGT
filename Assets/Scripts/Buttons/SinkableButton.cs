using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkableButton : Button {

    public int sinkableID;

    protected override void OnMouseClicked()
    {
        base.OnMouseClicked();
        GameManager.SetPlayerSinkable(sinkableID);
    }
}
