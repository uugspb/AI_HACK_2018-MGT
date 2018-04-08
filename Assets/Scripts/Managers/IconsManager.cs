using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsManager : MonoBehaviour
{
	private static IconsManager instance;
	
	public List<SinkableButton> icons;
	
	
	// Use this for initialization
	void Start ()
	{
		instance = this;
	}

	public static IconsManager GetI()
	{
		return instance;
	}

	public void BlockIcon(int sinkableID)
	{
		icons[sinkableID].Block();
	}
}
