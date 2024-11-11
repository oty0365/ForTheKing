using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class SlimeAi : EnemyAi
{
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        movespeed = 1.5f;
        faceing = "right";
        
    }

    private void OnEnable()
    {
        damage = 1f;
        hp = 30f;
        SetUpEnemy();
        SetUpBehavior();
        CheckBehavior();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        EnemyFlip(faceing);
        CheckBehavior();
        StatusCheck();
        DeathCheck();
    }

    private void SlowSlip()
    {
        movespeed = 0.9f;
    }

    private void NormalSlip()
    {
        movespeed = 1.5f;
    }
}
