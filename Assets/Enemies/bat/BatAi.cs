using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BatAi : enemyAi
{
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        movespeed = 3f;
        faceing = "left";
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        EnemyFlip(faceing);
    }
}
