using System;
using Enemies;
using UnityEngine;

public class GoblinAI : EnemyAi
{
    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        movespeed = 2f;
        faceing = "right";
        

    }

    private void OnEnable()
    {
        hp = 50f;
        SetUpBehavior();
        CheckBehavior();
    }

    public void Update()
    {
        MoveToPlayer();
        EnemyFlip(faceing);
        CheckBehavior();
        StatusCheck();

    }
    
}