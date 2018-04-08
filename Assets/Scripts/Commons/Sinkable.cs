using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SinkableStateEnum { NONE, SINKING, STAYING, RISING }

public class Sinkable : Dieble {
    public int sinkableID;
    public Vector2 sinkTarget;
    public SinkableConfig sinkableConfig;
    public bool mustStay = true;
    public bool mustRise = true;
    public float explosionRadius;

    private Vector3 previousPosition;
    protected SinkableStateEnum state = SinkableStateEnum.NONE;
    private float currentStayTime;

    public void Sink()
    {
        Debug.Log("Sinking");
        state = SinkableStateEnum.SINKING;
        previousPosition = transform.position;

        if (!mustStay)
        {
            sinkTarget = new Vector2(sinkTarget.x, Camera.main.transform.position.y - Camera.main.orthographicSize);
        }
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
	protected virtual void Update () {
        if (state == SinkableStateEnum.SINKING)
        {
            if (!mustStay && transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
            {
                Die();
                fullDestroy();

            }
            else if (sinkTarget.y < transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, sinkTarget, sinkableConfig.sinkSpeed * Time.deltaTime);
            }
            else
            {
                Debug.Log("Stay with mustStay: " + mustStay);
                Stay();
            }
        }
        else if (state == SinkableStateEnum.STAYING)
        {
            if(mustRise && currentStayTime <= 0)
            {
                Rise();
            }
            else if(currentStayTime > 0)
            {
                currentStayTime -= Time.deltaTime;
            }
            else if(!mustRise && currentStayTime <= 0)
            {
                Explosion();
                Die();
                fullDestroy();
            }

        }
        else if (state == SinkableStateEnum.RISING)
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

    protected virtual void Explosion()
    {
        
    }
}
