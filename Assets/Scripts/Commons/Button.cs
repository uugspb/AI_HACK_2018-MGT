using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public bool click;

    private void OnMouseDown()
    {
        click = true;
    }

    private void OnMouseUp()
    {
        click = false;
        OnMouseClicked();
    }

    protected virtual void OnMouseClicked()
    {

    }

    private void Update()
    {
        if (click)
        {
           
        }
    }
}
