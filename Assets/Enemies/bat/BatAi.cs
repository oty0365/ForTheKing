using System.Collections;
using System.Collections.Generic;
using Enemies;
using Unity.VisualScripting;
using UnityEngine;

public class BatAi :EnemyAi
{
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        movespeed = 3f;
        faceing = "left";
    }
    private void OnEnable()
    {
        damage = 4f;
        hp = 15f;
        SetUpEnemy();
        CheckBehavior();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        EnemyFlip();
        CheckBehavior();
        StatusCheck();
        DeathCheck();
    }
}
