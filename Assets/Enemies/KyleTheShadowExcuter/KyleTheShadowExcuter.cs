using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class KyleTheShadowExcuter : BossAi
{
    private void Start()
    {
        SetUpBoss();
        behavior = Behavior.Idle;
    }

    private void Update()
    {
        switch (behavior)
        {
            case Behavior.Idle:
                monsterAni.SetInteger("behave",0);
                break;
            case Behavior.Chase:
                monsterAni.SetInteger("behave",1);
                Chase();
                break;
                
        }
        EnemyFlip();
    }

    public override void Think()
    {
        var distance = Vector2.Distance(gameObject.transform.position, playerdata.transform.position);
        if (distance >=skills[0].skillMinRange && distance <= skills[0].skillMaxRange)
        {
            behavior = Behavior.Chase;
        }
        else
        {
            behavior = Behavior.Idle;
        }
    }
    
    
}
