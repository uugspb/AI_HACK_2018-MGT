using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishMind {

    private List<TrapInfo> trapInfoList;

    public FishMind(List<TrapInfo> trapInfoList)
    {
        this.trapInfoList = trapInfoList;
    }

	public bool CheckTrap(float trapDistance, int trapID)
	{
        float randomValue = Random.Range(0, 1f);
        Debug.Log("Check Trap " + trapInfoList[trapID].probability + "\nRandom Value: " + randomValue + " Total: "
            + ((1 / Mathf.Clamp(trapDistance, 1, trapDistance)) * trapInfoList[trapID].probability));
		return  randomValue < 
            ((1/Mathf.Clamp(trapDistance, 1, trapDistance)) * trapInfoList[trapID].probability);
	}
}
