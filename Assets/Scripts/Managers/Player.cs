using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int sinkableID;
	public int hitPower;
	public bool isTakeSinkable;

    private float height;
    private float width;
    public float bottomHeightBound;
    public float topHeightBound;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update ()
	{
		if (isTakeSinkable && Input.GetMouseButtonDown(0))
		{
			Vector3 clickPos = GetPosition();
            Debug.Log(clickPos);
            Debug.Log(Camera.main.transform.position);
            if (!ClickInGameZone(clickPos))
                return;
			SinkableGenerator.GetI().Generate(clickPos,sinkableID);
			isTakeSinkable = false;
		}
		
	}

    private bool CheckHeight(float height, Vector3 position, Vector3 click)
    {
        if (
            /* position.x - width / 2.0f > click.x
            && position.x + width / 2.0f < click.x
            &&*/ position.y - height + bottomHeightBound < click.y
            && position.y + height - topHeightBound > click.y)
            return true;

        return false;
    }

    bool ClickInGameZone(Vector3 clickPos)
    {
        Debug.Log(Camera.main.orthographicSize);
        return CheckHeight(Camera.main.orthographicSize, Camera.main.transform.position, clickPos);
    }


    Vector3 GetPosition()
	{
		Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
		return Camera.main.ScreenToWorldPoint(position);
	}
}
