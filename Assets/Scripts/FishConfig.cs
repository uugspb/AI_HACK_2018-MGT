using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="FishConfig", menuName ="Create FishConfig")]

public class FishConfig : ScriptableObject {
    public float speed;
    public float moveAmplitude;
    public int maxHP;
    public int gold;
    public Sprite kindFish;
	
}
