using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public bool click;
    public static Color grayColor;

    private void OnValidate()
    {
        grayColor = new Color(0.1f,0.1f,0.1f,1);
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = grayColor;
        click = true;
    }

    private void OnMouseUp()
    {
        click = false;
        
        OnMouseClicked();
    }

    protected virtual void OnMouseClicked()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Update()
    {
        if (click)
        {
           
        }
    }
}
