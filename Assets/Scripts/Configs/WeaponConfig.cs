using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName="WeaponConfig", menuName = "Create WeaponConfig")]
public class WeaponConfig : ScriptableObject {
	public float cooldown;
    public int hitPower;
	
}
