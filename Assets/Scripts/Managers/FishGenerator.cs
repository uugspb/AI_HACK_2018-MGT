﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishGenerator : DiebleEventChecker
{
	[SerializeField] 
	private GameObject fishPrefab;

	private static FishGenerator instance;
	
	public int fishCount;
	public int maxFishCount;
	
	private float height;
	private float width;

	private List<Fish> fishList;
	
	// Use this for initialization
	void Start ()
	{
		instance = this;
		fishList = new List<Fish>();
		
		height = Camera.main.scaledPixelHeight;
		width = Camera.main.scaledPixelWidth;
		CreateStartFishes();
	}

	public static FishGenerator GetI()
	{
		return instance;
	}
	
	void Update()
	{
		while (fishList.Count < maxFishCount && fishCount > 0)
		{
			CreateFish();
		}
	}

	public void deleteFish(Dieble fish)
	{
		fishList.Remove((Fish)fish);
	}
	
	public void CreateStartFishes()
	{
		for (int i = 0; i < maxFishCount && i <fishCount; i++)
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
		
		fishList.Add(fish);
		fish.RegisterListener(deleteFish);
		
		fishCount--;
	}

	public Fish getFish(Vector3 clickPosition)
	{
		foreach (Fish fish in fishList)
		{
			Vector2 size = fish.GetComponent<SpriteRenderer>().size;
			if (checkBox(size.y, size.x, fish.transform.position, clickPosition))
				return fish;
		}

		return null;
	}

	private bool checkBox(float height, float width, Vector3 position, Vector3 click)
	{
		if (position.x - width / 2.0f < click.x
		    && position.x + width / 2.0f > click.x
		    && position.y - height / 2.0f < click.y
		    && position.y + height / 2.0f > click.y)
			return true;
		
		return false;
	}
}