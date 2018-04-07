using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMind : MonoBehaviour {

	private List<float> trapProbabilityList;

    public FishMind(List<float> trapProbabilityList)
    {
        this.trapProbabilityList = trapProbabilityList;
    }

	bool CheckTrap(float trapDistance, int trapID)
	{
		return true;
	}
}
