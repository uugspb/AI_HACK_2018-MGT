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

		levelConfigs = new List<LevelConfig>(levelsCount);
	}

	public static LevelManager GetI()
	{
		return instance;
	}

	public void nextLevel()
	{
		if (currentLevel < levelsCount - 1)
			currentLevel++;
		Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, levelConfigs[currentLevel].cameraPosition,
			cameraSpeed * Time.deltaTime);
	}

	public LevelConfig GetConfig()
	{
		return levelConfigs[currentLevel];
	}
}
