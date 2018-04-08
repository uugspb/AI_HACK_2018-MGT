using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SinkableConfig", menuName = "Create Sinkable Config")]

public class SinkableConfig : ScriptableObject {
    public float sinkSpeed;
    public float stayTime;
    public float cooldown;
}
