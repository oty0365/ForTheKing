using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAi : enemyAi
{
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        movespeed = 1.5f;
        faceing = "right";
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        EnemyFlip(faceing);
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
