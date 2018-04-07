using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SinkableStateEnum { NONE, SINKING, STAYING, RISING }

public class Sinkable : Dieble {
    public int sinkableID;
    public Vector2 sinkTarget;
    public SinkableConfig sinkableConfig;

    private Vector3 previousPosition;
    protected SinkableStateEnum state = SinkableStateEnum.NONE;
    private float currentStayTime;

    public void Sink()
    {
        Debug.Log("Sinking");
        state = SinkableStateEnum.SINKING;
        previousPosition = transform.position;
    }

    public virtual void Stay()
    {
        state = SinkableStateEnum.STAYING;
        currentStayTime = sinkableConfig.stayTime;
    }

    public virtual void Rise()
    {
        Debug.Log("Rising");
        state = SinkableStateEnum.RISING;
    }
	
	// Update is called once per frame
	void Update () {
        if (state == SinkableStateEnum.SINKING)
        {
            if (sinkTarget.y < transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, sinkTarget, sinkableConfig.sinkSpeed * Time.deltaTime);
            }
            else
            {
                Stay();
            }
        }
        else if (state == SinkableStateEnum.STAYING)
        {
            if(currentStayTime < 0)
            {
                Rise();
            }

            currentStayTime -= Time.deltaTime;
        } else if (state == SinkableStateEnum.RISING)
        {
            if (previousPosition.y > transform.position.y)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, previousPosition, sinkableConfig.sinkSpeed * Time.deltaTime);
            }
            else
            {
                Die();
                fullDestroy();
            }
        }
	}
}
