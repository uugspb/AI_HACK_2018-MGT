using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiebleEvent : UnityEvent<Dieble>
{

}

public class Dieble : MonoBehaviour {

    private DiebleEvent m_diebleEvent = new DiebleEvent();

    public void InvokeEvent()
    {
        if (m_diebleEvent != null)
        {
            m_diebleEvent.Invoke(this);
        }
    }

    public void RegisterListener(UnityAction<Dieble> call)
    {
        if (m_diebleEvent != null)
            m_diebleEvent.AddListener(call);
    }

    public virtual void Die()
    {
        PrepareToDie();
        InvokeEvent();
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
