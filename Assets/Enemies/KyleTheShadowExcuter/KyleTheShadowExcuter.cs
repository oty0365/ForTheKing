using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

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
            case Behavior.Attack1:
                monsterAni.SetInteger("behave",0);
                monsterAni.SetBool("attacking",true);
                monsterAni.SetTrigger("attack1");
                break;
            case Behavior.Attack2:
                monsterAni.SetInteger("behave",0);
                monsterAni.SetBool("attacking",true);
                monsterAni.SetTrigger("attack2");
                break;
        }
        EnemyFlip();
    }

    public override void Think()
    {
        monsterAni.SetBool("attacking",false);
        var distance = Vector2.Distance(gameObject.transform.position, playerdata.transform.position);
        if (distance >=skills[0].skillMinRange && distance <= skills[0].skillMaxRange)
        {
            var skills = Random.Range(0, 2);
            switch (skills)
            {
                case 0:
                    behavior = Behavior.Chase;
                    break;
                case 1:
                    behavior = Behavior.Attack2;
                    break;
            }
        }
        else if (distance >=skills[1].skillMinRange && distance <= skills[1].skillMaxRange)
        {
            behavior = Behavior.Attack1;

        }
        else if (distance >=skills[2].skillMinRange && distance <= skills[2].skillMaxRange)
        {
            behavior = Behavior.Attack2;
        }
        else
        {
            behavior = Behavior.Idle;
        }
    }
    
    
}
