using System;
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
	public float bottomGenBorder;
	public float topGenBorder;
	public float maxRandomInterval;
	
	private float height;
	private float width;

	public List<Fish> fishList;

	private float timeForCreate = 0;
	private float currentInterval = 1;
	private bool isStopped = false;
	
	// Use this for initialization
	protected override void Start ()
	{
        base.Start();

		instance = this;
		fishList = new List<Fish>();
		
		height = Camera.main.scaledPixelHeight;
		width = Camera.main.scaledPixelWidth;
		
		LevelConfig config = LevelManager.GetI().GetConfig();
        fishPrefab = config.fishPrefab;
		fishCount = config.fishCount;
		maxFishCount = config.maxFishCount;
		//CreateStartFishes();
	}

	public static FishGenerator GetI()
	{
		return instance;
	}
	
	void Update()
	{
		timeForCreate += Time.deltaTime;
		
		while ((fishList.Count < maxFishCount) && (fishCount > 0) && (timeForCreate>=currentInterval) && !isStopped)
		{
			CreateFish();
			currentInterval = Random.Range(0, maxRandomInterval);
			timeForCreate = 0;
		}

		if (fishCount == 0 && fishList.Count == 0)
		{
			nextLevel();
		}

		
	}

	public void DeleteFish(Dieble fish)
	{
		fishList.Remove((Fish)fish);
	}

	public void DisappearFish(Fish fish)
	{
		float targetPos = Random.Range(height*bottomGenBorder, height*topGenBorder);
		Vector3 target;
		if (fish.GetTarget().x > 0)
		{
			target = Camera.main.ScreenToWorldPoint(new Vector3(-0.1f*width , targetPos));
		}
		else
		{
			target = Camera.main.ScreenToWorldPoint(new Vector3(1.1f*width , targetPos));
		}

		target.z = 0;
		fish.SetTarget(target);
		fish.updateAngle();
		
	}
	
	void CreateStartFishes()
	{
		for (int i = 0; i < maxFishCount && i < fishCount; i++)
		{
			CreateFish();
			
		}
	}

	private void CreateFish()
	{
		int side = Random.Range(0, 2);
		float startPos = Random.Range(height*bottomGenBorder, height*topGenBorder);
		float targetPos = Random.Range(height*bottomGenBorder, height*topGenBorder);

		Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(side*width,startPos));
		Vector3 target =  Camera.main.ScreenToWorldPoint(new Vector3(side == 0 ? width : 0 , targetPos));
		position.x *= 1.1f;
		target.x *= 1.1f;
		position.z = target.z = 0;

		Vector3 cameraDifference = LevelManager.GetI().GetConfig().cameraPosition-Camera.main.transform.position;
		cameraDifference.z = 0;
		Fish fish = Instantiate(fishPrefab, position+cameraDifference, Quaternion.identity).GetComponent<Fish>();
		fish.SetTarget(target + cameraDifference);
        fish.SetMind(OceanMind.GetCurrentFishMind());
        SpriteRenderer spriteRenderer = fish.GetComponent<SpriteRenderer>();
        spriteRenderer.color = GetColor();

		
		fishList.Add(fish);
		fish.RegisterListener(DeleteFish);
		fish.RegisterDisappearListener(DisappearFish);
		
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

	public void nextLevel()
	{
		LevelManager.GetI().nextLevel();
		LevelConfig config = LevelManager.GetI().GetConfig();

        fishPrefab = config.fishPrefab;
        fishCount = config.fishCount;
		maxFishCount = config.maxFishCount;
		
		//CreateStartFishes();
	}

    public Color GetColor()
    {
        Color newColor = new Color(Random.Range(0, 255)/100, Random.Range(0, 255)/100, Random.Range(0, 255)/100);
        return newColor;
    }

	public void Stop()
	{
		isStopped = true;
	}
}
