using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class enemyAi : MonoBehaviour
{
    [SerializeField] private GameObject playerdata;
    public float movespeed;
    protected SpriteRenderer sr;
    public string faceing;
    // Start is called before the first frame update
   protected void Start()
   {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        EnemyFlip(faceing);
    }

    protected void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, playerdata.transform.position, movespeed*Time.deltaTime);
    }

    protected void EnemyFlip(string faceing)
    {
        if (this.faceing == "right")
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
        else if (this.faceing == "left")
        {
            if (gameObject.transform.position.x - playerdata.transform.position.x > 0)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        }

    }
    
    
    
}
