using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using WeponS;

namespace Enemies
{
    public enum Behavior
    {
        Idle,
        Chase,
        Dash,
        Attack1,
        Attack2,
        Attack3,
        Attack4,
        Attack5,
        Ultimate,
        Death,
        Thinking,
    }

    public class EnemyAi : Entity
    {
        protected GameObject playerdata;
        protected PlayerStatus _playerStatus;
        protected Animator monsterAni;
        public float exp;
        protected SpriteRenderer sr;
        public Behavior behavior;
        public string faceing;
        public float damage;
        public GameObject deathParticle;
        [Header("크키 입력")] public Vector2 scale;
        protected Vector2 xdir;
        protected Vector2 mxdir;
        

        protected void SetUpEnemy()
        {
            behavior = Behavior.Idle;
            sr = gameObject.GetComponent<SpriteRenderer>();
            playerdata = GameObject.FindWithTag("player").gameObject;
            _playerStatus = playerdata.GetComponent<PlayerStatus>();
            monsterAni = GetComponent<Animator>();
            if (faceing == "right")
            {
                xdir = new Vector2(scale.x,
                    scale.y);
                mxdir = new Vector2(-scale.x,
                    scale.y);
            }
            else
            {
                xdir = new Vector2(-scale.x,
                    scale.y);
                mxdir = new Vector2(scale.x, 
                    scale.y);
            }

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

        protected void EnemyFlip()
        {
            
            var dir = gameObject.transform.position.x - playerdata.transform.position.x;
                if (dir > 0)
                {
                    gameObject.transform.localScale = xdir;
                    
                }
                else
                {
                    gameObject.transform.localScale = mxdir;
                }
            
        }
        
        protected void DeathCheck()
        {
            if (!MonsterGenerator.keepGenerate)
            {
                hp = 0;
            }
            if (hp <= 0)
            {
                if (MonsterGenerator.keepGenerate)
                {
                    PlayerStatus.instance.Exp += exp;   
                }
                _playerStatus.SetExp();
                ObjectPooler.instance.Get(deathParticle,gameObject.transform.position,Quaternion.identity);
                ObjectPooler.instance.Return(gameObject);
            }
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("weapon"))
            {
                StartCoroutine(HitFlow());
            }
        }

        protected IEnumerator HitFlow()
        {
            var origin = sr.color;
            for (var i = 1f; i >= 0f; i -= Time.deltaTime*4)
            {
                sr.color = new Color(i, i, i, 1);
                yield return null;
            }
            sr.color = origin;
        }
        
    }
}
