using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class goblinAI : enemyAi
{
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        movespeed = 2f;
        faceing = "right";
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        EnemyFlip(faceing);

    }
    
}