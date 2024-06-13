using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    [SerializeField] private GameObject playerdata;
    public float movespeed;
    protected SpriteRenderer sr;
    // Start is called before the first frame update
   protected void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        EnemyFlip();
    }

    protected void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, playerdata.transform.position, movespeed*Time.deltaTime);
    }

    protected void EnemyFlip()
    {
        if (gameObject.transform.position.x - playerdata.transform.position.x > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    
}
