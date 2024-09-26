using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class SlimeAi : EnemyAi
{
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        movespeed = 1.5f;
        faceing = "right";
        
    }

    private void OnEnable()
    {
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
