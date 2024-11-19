using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using WeponS;

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
        protected PlayerStatus _playerStatus;
        protected Animator monsterAni;
        public float exp;
        protected SpriteRenderer sr;
        public Behavior behavior;
        public string faceing;
        public float damage;
        public GameObject deathParticle;
        

        protected void SetUpEnemy()
        {
            sr = gameObject.GetComponent<SpriteRenderer>();
            playerdata = GameObject.FindWithTag("player").gameObject;
            _playerStatus = playerdata.GetComponent<PlayerStatus>();
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
