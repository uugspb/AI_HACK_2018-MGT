using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dieble : MonoBehaviour {

    protected virtual void Die()
    {
        PrepareToDie();
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
	
    public virtual void ReceiveKill()
    {
        Die();
    }

    protected virtual void PrepareToDie()
    {

    }
}
