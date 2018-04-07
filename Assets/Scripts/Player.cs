using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public int hitPower;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 clickPos = GetPosition();
			Fish fish = FishGenerator.GetI().getFish(clickPos);
			if (fish == null)
				return;

			if (!fish.IsFishMove())
			{
				fish.Hit(hitPower);
			}
				
		}
		
	}
	
	Vector3 GetPosition()
	{
		Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
		return Camera.main.ScreenToWorldPoint(position);
	}
}
