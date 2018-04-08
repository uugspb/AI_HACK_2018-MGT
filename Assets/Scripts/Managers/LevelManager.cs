using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	private static LevelManager instance;

	public int levelsCount;
	public float cameraSpeed;
	public List<LevelConfig> levelConfigs;
	
	public bool isStart = true;

	
	public int currentLevel = 0;
	
	// Use this for initialization
	void Start ()
	{
		instance = this;
		MusicManager.GetI().SetMusic(levelConfigs[currentLevel].musicID);
	}

	public static LevelManager GetI()
	{
		return instance;
	}

	public void nextLevel()
	{
		if (currentLevel == 0 && isStart)
			isStart = false;
		else if (currentLevel < levelsCount - 1)
		{
			currentLevel++;
			MusicManager.GetI().SetMusic(levelConfigs[currentLevel].musicID);
		}

	}

	public LevelConfig GetConfig()
	{
		return levelConfigs[currentLevel];
	}

	void Update()
	{
		if (!isStart && (Camera.main.transform.position.y > levelConfigs[currentLevel].cameraPosition.y))
		{
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, levelConfigs[currentLevel].cameraPosition,
				cameraSpeed * Time.deltaTime);
		}
	}
	
	
}
