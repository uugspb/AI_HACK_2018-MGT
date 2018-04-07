using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int sinkableID;
	public int hitPower;
	public bool isTakeSinkable;
	
	// Update is called once per frame
	void Update ()
	{
		if (isTakeSinkable && Input.GetMouseButtonDown(0))
		{
			Vector3 clickPos = GetPosition();
			SinkableGenerator.GetI().Generate(clickPos,sinkableID);
		}
		
	}
	
	Vector3 GetPosition()
	{
		Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
		return Camera.main.ScreenToWorldPoint(position);
	}
}
