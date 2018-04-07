using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.WSA;

public class DisappearEvent : UnityEvent<Fish>
{

}


public class Fish : Dieble {

    [SerializeField]
    private FishConfig fishConfig;

    public Vector3 target;
    public FishMind mind;
    public double angle;
    public float speed;

    private SpriteRenderer spriteRenderer;
    private bool isFishMove;
    private int currentHP;

    private DisappearEvent m_disappearEvent = new DisappearEvent();

    private void Start()
    {
        angle = (Math.Asin((target.y - this.transform.position.y) / Vector3.Distance(this.transform.position, target)) / 3.14f) * 180;
        speed = fishConfig.speed;
        FishMove();
    }

    void Update () {
        if (isFishMove)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, (float)angle);
            if (target.x - this.transform.position.x >= 0)
                this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, 0, (float)angle);
            else
                this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, 180, (float)angle);
            
            CheckDisappear();
        }
    }

    void FishMove()
    {
        isFishMove = true;


    }

    void FishStay()
    {
        isFishMove = false;
        speed = 0;
        //анимация в стоячем положении
    }

    bool IsFishMove()
    {
        return isFishMove;
    }

    void Hit(int hitPower)
    {
        currentHP -= hitPower;
        CheckHP();
    }

    void CheckHP()
    {
        if (currentHP <= 0)
            Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Trap")
        {
            FishStay();
        }
    }

    private void CheckDisappear()
    {
        float posX = Camera.main.WorldToScreenPoint(transform.position).x;
        float camWidth = Camera.main.pixelWidth;
        if((transform.position == target) && (posX<0 || posX>camWidth))
            Disappear();
            
    }
    
    public void RegisterDisappearListener(UnityAction<Fish> call)
    {
        if (m_disappearEvent != null)
            m_disappearEvent.AddListener(call);
    }

    private void Disappear()
    {
        if (m_disappearEvent != null)
        {
            m_disappearEvent.Invoke(this);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
