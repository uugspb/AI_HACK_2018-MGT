using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiebleEventChecker : MonoBehaviour {

    public List<Dieble> diebleList;

    protected virtual void Start()
    {
        foreach (Dieble dieble in diebleList)
        {
            dieble.RegisterListener(OnInvokeEvent);
        }
    }

    public virtual void OnInvokeEvent(Dieble diebleObject)
    {
        
    }
}
