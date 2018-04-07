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
    }

    private void Update()
    {
        if (click)
        {
            Debug.Log("Action");
        }
    }
}
