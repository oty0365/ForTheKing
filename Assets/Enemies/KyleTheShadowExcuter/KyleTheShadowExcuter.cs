using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class KyleTheShadowExcuter : BossAi
{
    private void Start()
    {
        SetUpBoss();
        behavior = Behavior.Thinking;
    }

    private void DisCaution()
    {
        var distance = Vector2.Distance(gameObject.transform.position, playerdata.transform.position);
        if (skills[0].skillMinRange <= distance && distance <= skills[0].skillMaxRange)
        {
            
        }
        else if (skills[1].skillMinRange <= distance && distance <= skills[1].skillMaxRange)
        {
            
        }
        
    }
    
    
}
