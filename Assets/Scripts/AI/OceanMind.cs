using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanMind : MonoBehaviour
{
    private static OceanMind instance;
	private List<TrapInfo> trapInfoList;

    public static float[] oceanTrapProbabilitiesByKills = new float[] {0, 4, 8, 12, 16, 20, 24, 25.5f, 27.5f, 30, 33,
                                                                        36.5f, 40.5f, 45, 50, 61, 65.5f, 69, 72, 77, 79.1f,
                                                                        81.1f, 83, 84.7f, 86.5f, 88.1f, 89.6f, 91.1f, 92.6f, 94};
	
	public float startProbablility;
    public int trapsCount;

    private void Start()
    {
        instance = this;
        trapInfoList = new List<TrapInfo>(trapsCount);
        for(int i = 0; i < trapsCount; i++)
        {
            trapInfoList.Add(new TrapInfo(i, startProbablility));
        }
    }

    public static FishMind GetCurrentFishMind()
	{
		return new FishMind(instance.trapInfoList);
	}

    public static void LearnTrap(int trapID)
    {
        instance.trapInfoList[trapID].fishKills++;
        instance.trapInfoList[trapID].probability =
            1 - oceanTrapProbabilitiesByKills[Mathf.Clamp(instance.trapInfoList[trapID].fishKills,
            0, oceanTrapProbabilitiesByKills.Length)];
    }
}
