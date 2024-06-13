using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinAI : enemyAi
{
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        movespeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        EnemyFlip();
    }
}