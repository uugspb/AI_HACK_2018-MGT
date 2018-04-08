using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisappearEvent : UnityEvent<Fish>
{

}


public class Fish : Dieble {

    [SerializeField]
    private FishConfig fishConfig;

    private Vector3 target;
    private FishMind mind;
    private double targetAngle;
    private float speed;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isFishMove;
    public int currentHP;
    private bool isDie = false;

    private float currentStayTime;
    private double trapAngle;
    private Vector3 trapTarget;
    private int trapKillerID;

    private Vector3 weaponTarget;
    private int weaponKillerID;

    private DisappearEvent m_disappearEvent = new DisappearEvent();

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        speed = fishConfig.speed;
        currentHP = fishConfig.maxHP;

        updateAngle();
        FishMove();
    }

    public void updateAngle()
    {
        targetAngle = CalculateAngle(target);
    }
    void Update () {
        if (isFishMove)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
            
            //transform.LookAt(target);
            SetAngle(target, targetAngle);
            //Debug.Log("Target");
            CheckDisappear();
        }
        else if (isDie)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            if(Camera.main.WorldToScreenPoint(transform.position).y<0)
                fullDestroy();
        } 
        else
        {
            if(currentStayTime < 0)
            {
                FishMove();
            }
            else
            {
                currentStayTime -= Time.deltaTime;
                //trapAngle = CalculateAngle(trapTarget);
                SetAngle(trapTarget, trapAngle);
                //transform.LookAt(trapTarget);
            }
        }
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }

    public void SetMind(FishMind fishMind) 
    {
        this.mind = fishMind;
    }

    private double CalculateAngle(Vector3 angleTarget)
    {
        return (Math.Asin((angleTarget.y - this.transform.position.y) 
            / Vector3.Distance(this.transform.position, angleTarget)) / 3.14f) * 180;
    }

    private void SetAngle(Vector3 angleTarget, double angle)
    {
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, (float)angle);
        if (angleTarget.x - this.transform.position.x >= 0)
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, 0, (float)angle);
        else
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, 180, (float)angle);
    }

    void FishMove()
    {
        isFishMove = true;
        speed = fishConfig.speed;

    }

    void FishStay(int freezeTime)
    {
        isFishMove = false;
        speed = 0;

        currentStayTime = freezeTime;
    }

    bool IsFishMove()
    {
        return isFishMove;
    }

    public void Hit(int hitPower)
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
            Trap trap = collision.gameObject.GetComponent<Trap>();
            trapTarget = collision.gameObject.transform.position;
            if (mind.CheckTrap(Vector2.Distance(transform.position, trapTarget), trap.sinkableID))
            {
                // Set angle to Trap
                trapAngle = CalculateAngle(trapTarget);
                FishStay(trap.config.fishFreezeTime);
                trapKillerID = trap.sinkableID;
            }

        }
        else if(!IsFishMove() && collision.tag == "Weapon")
        {
            Weapon weapon = collision.gameObject.GetComponent<Weapon>();
            Hit(weapon.config.hitPower);
            Debug.Log("weapon");
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
        }
    }

    public override void Die()
    {
        OceanMind.LearnTrap(trapKillerID);

        animator.enabled = false;
        spriteRenderer.sprite = fishConfig.deathFish;
        isDie = true;
        isFishMove = false;
    }
}
