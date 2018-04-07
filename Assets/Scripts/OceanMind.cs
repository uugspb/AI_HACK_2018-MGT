using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanMind : MonoBehaviour
{
	[SerializeField]
	private List<float> trapProbabilityList;
	
	public int trapsCount;
	public float startProbablility;

	public static FishMind GetCurrentFishMind()
	{
		return new FishMind();
	}
}
