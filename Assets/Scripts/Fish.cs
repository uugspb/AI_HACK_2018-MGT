using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Dieble {

    [SerializeField]
    private FishConfig fishConfig;

    public Vector3 target;
    public FishMind mind;
    public double ungle;

    private SpriteRenderer spriteRenderer;
    private bool isFishMove;
    private int currentHP;

    void Start()
    {
        ungle = 180 - Vector3.Angle(this.transform.position, target);
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fishConfig.kindFish;
    }

    void Update () {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, fishConfig.speed * Time.deltaTime);
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y,(float)ungle);
        if (target.x-this.transform.position.x >= 0)
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, 0, (float)ungle);
        else
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, 180, (float)ungle);
    }

    void FishMove()
    {
        isFishMove = true;
    }

    void FishStay()
    {
        isFishMove = false;
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
}
