using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanMind : MonoBehaviour
{
    private static OceanMind instance;
	private List<TrapInfo> trapInfoList;

    public static float[] oceanTrapProbabilitiesByKills = new float[] {0, 0.04f, 0.08f, 0.12f, 0.16f, 0.2f, 0.24f, 0.255f, 0.275f,
                                                                        0.30f, 0.33f, 0.365f, 0.405f, 0.45f, 0.50f, 0.61f, 0.655f,
                                                                        0.69f, 0.72f, 0.77f, 0.791f, 0.811f, 0.83f, 0.847f, 0.865f,
                                                                        0.881f, 0.896f, 0.911f, 0.926f, 0.94f};
	
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
        //Debug.Log("LearnTrap: " + trapID + "\nKills: " + instance.trapInfoList[trapID].fishKills);
        instance.trapInfoList[trapID].fishKills++;
        instance.trapInfoList[trapID].probability =
            1 - oceanTrapProbabilitiesByKills[Mathf.Clamp(instance.trapInfoList[trapID].fishKills,
            0, oceanTrapProbabilitiesByKills.Length - 1)];
        /*Debug.Log("EndLearnTrap Kills: " + instance.trapInfoList[trapID].fishKills +
            "\nOceanProbability: " + oceanTrapProbabilitiesByKills[Mathf.Clamp(instance.trapInfoList[trapID].fishKills,
            0, oceanTrapProbabilitiesByKills.Length - 1)]);*/
    }
}
