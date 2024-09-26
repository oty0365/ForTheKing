using System;
using UnityEngine;

namespace Enemies
{
    public enum Behavior
    {
        idle,
        chase,
        dash,
        attack1,
        attack2,
        attack3,
        attack4,
        attack5,
        ultimate,
        death,
    }

    public class EnemyAi : Entity
    {
        protected GameObject playerdata;
        protected Animator monsterAni;
        public float hp;
        protected SpriteRenderer sr;
        public Behavior behavior;
        public string faceing;
        public float damage;
        protected void Start()
        {
            sr = gameObject.GetComponent<SpriteRenderer>();
        }
        
        void Update()
        {
            MoveToPlayer();
            EnemyFlip(faceing);
        }

        protected void SetUpEnemy()
        {
            playerdata = GameObject.FindWithTag("player").gameObject;
            monsterAni = GetComponent<Animator>();
        }
        

        protected void SetUpBehavior()
        {
            behavior = Behavior.idle;
            
        }

        protected void CheckBehavior()
        {
            /*switch (behavior)
            {
                //case Behavior.idle:
                    //mosetrAni.SetBool();
            }*/
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
}
