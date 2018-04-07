using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishGenerator : MonoBehaviour
{
	[SerializeField] 
	private GameObject fishPrefab;

	public int fishCount;
	
	private float height;
	private float width;
	
	
	
	// Use this for initialization
	void Start ()
	{
		height = Camera.main.scaledPixelHeight;
		width = Camera.main.scaledPixelWidth;
		CreateStartFishes();
	}

	void Update()
	{
		
	}
	
	public void CreateStartFishes()
	{
		for (int i = 0; i < fishCount; i++)
		{
			CreateFish();
		}
	}

	private void CreateFish()
	{
		int side = Random.Range(0, 2);
		float startPos = Random.Range(0, height);
		float targetPos = Random.Range(0, height);

		Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(side*width,startPos));
		Vector3 target =  Camera.main.ScreenToWorldPoint(new Vector3(side == 0 ? width : 0 , targetPos));
		position.x *= 1.1f;
		target.x *= 1.1f;
		position.z = target.z = 0;

		Fish fish = Instantiate(fishPrefab, position, Quaternion.identity).GetComponent<Fish>();
		fish.target = target;
	}
}
