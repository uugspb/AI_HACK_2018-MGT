using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Dieble {

    [SerializeField]
    private FishConfig fishConfig;

    public Vector3 target;
    public FishMind mind;
    public double angle;

    private SpriteRenderer spriteRenderer;
    private bool isFishMove;
    private int currentHP;

    void OnValidate()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fishConfig.kindFish;
    }

    private void Start()
    {
        angle = (Math.Asin((target.y - this.transform.position.y) / Vector3.Distance(this.transform.position, target)) / 3.14f) * 180;
    }

    void Update () {
        //target = getPosition();
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, fishConfig.speed * Time.deltaTime);
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, (float)angle);
        if (target.x-this.transform.position.x >= 0)
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, 0, (float)angle);
        else
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, 180, (float)angle);
    }

    Vector3 getPosition()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        return Camera.main.ScreenToWorldPoint(position);
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
