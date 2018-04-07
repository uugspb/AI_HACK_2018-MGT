using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLvlButton : Button {

	protected override void OnMouseClicked()
	{
		
		base.OnMouseClicked();
		if (LevelManager.GetI().isStart)
		{
			LevelManager.GetI().isStart = false;
			return;
		}
		foreach (Fish fish in FishGenerator.GetI().fishList)
		{
			fish.Die();
		}

		FishGenerator.GetI().fishCount = 0;
	}
}
