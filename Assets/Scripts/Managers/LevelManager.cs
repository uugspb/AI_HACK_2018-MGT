using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	private static LevelManager instance;

	public int levelsCount;
	public float cameraSpeed;
	public List<LevelConfig> levelConfigs;

	
	public int currentLevel = 0;
	
	// Use this for initialization
	void Start ()
	{
		instance = this;
	}

	public static LevelManager GetI()
	{
		return instance;
	}

	public void nextLevel()
	{
		if (currentLevel < levelsCount - 1)
			currentLevel++;
	}

	public LevelConfig GetConfig()
	{
		return levelConfigs[currentLevel];
	}

	void Update()
	{
		if (Camera.main.transform.position.y > levelConfigs[currentLevel].cameraPosition.y)
		{
			Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, levelConfigs[currentLevel].cameraPosition,
				cameraSpeed * Time.deltaTime);
		}
	}
}
