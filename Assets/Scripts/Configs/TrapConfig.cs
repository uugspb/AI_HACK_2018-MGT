using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrapConfig", menuName = "Create Trap Config")]

public class TrapConfig : ScriptableObject
{
    public float cooldown;
    public int fishFreezeTime;
    public float liveTime;
}
