using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanMind : MonoBehaviour
{
    private static OceanMind instance;
	private List<float> trapProbabilityList;
	
	public float startProbablility;
    public int trapsCount;

    private void Start()
    {
        instance = this;
        trapProbabilityList = new List<float>(trapsCount);
        for(int i = 0; i < trapsCount; i++)
        {
            trapProbabilityList[i] = startProbablility;
        }
    }

    public static FishMind GetCurrentFishMind()
	{
		return new FishMind(instance.trapProbabilityList);
	}
}
