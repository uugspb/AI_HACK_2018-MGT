using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Create Level Config")]

public class LevelConfig : ScriptableObject
{
    public Vector3 cameraPosition;
    public int fishCount;
    public int maxFishCount;
    public GameObject fishPrefab;
    public int musicID;
}
