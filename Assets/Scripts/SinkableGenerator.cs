using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkableGenerator : MonoBehaviour {

	
	private static SinkableGenerator instance;
	private static List<Sinkable> sinkableList;
	
	private float height;
	
	// Use this for initialization
	void Start ()
	{
		instance = this;
		sinkableList = new List<Sinkable>();
		
		height = Camera.main.scaledPixelHeight;
	}
	
	public static SinkableGenerator GetI()
	{
		return instance;
	}

	public void Generate(Vector2 clickPosition, int sinkableID)
	{
		Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(0, height, 0));
		position.z = 0;
		position.x = clickPosition.x;

		Sinkable sinkablePrefab = getPrefab(sinkableID);

		Sinkable sinkable = Instantiate(sinkablePrefab, position, Quaternion.identity);
		sinkableList.Add(sinkable);

		sinkable.sinkTargetY = clickPosition.y;
		sinkable.Sink();
	}

	private Sinkable getPrefab(int sinkableID)
	{
		return GameManager.GetSinkableByID(sinkableID);
	}
}
