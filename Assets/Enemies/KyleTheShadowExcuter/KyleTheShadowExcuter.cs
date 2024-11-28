using System;
using System.Collections;
using Enemies;
using OtherObj;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class KyleTheShadowExcuter : BossAi
{
    [Header("투사체")]public GameObject dagger;
    private LineRenderer _lr;
    private bool _isDashing;
    private float _angle;
    public Quaternion _daggerQuaternion;
    public GameObject door;
    private void Start()
    {
        SetUpBoss();
        behavior = Behavior.Idle;
        _lr = GetComponent<LineRenderer>();
        _lr.enabled = false;
        _isDashing = false;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Instantiate(door, new Vector2(0, 0), Quaternion.identity);
            bossHpView.enabled = false;
            bossNameView.enabled = false;
            Destroy(gameObject);
            SceneManager.LoadSceneAsync("TitleScene");
        }
        bossHpView.value = hp;
        var dir = playerdata.transform.position - gameObject.transform.position;
        _angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        _daggerQuaternion = Quaternion.Euler(0,0,_angle);
        switch (behavior)
        {
            case Behavior.Idle:
                damage = 0;
                monsterAni.SetInteger("behave",0);
                break;
            case Behavior.Chase:
                damage = 0;
                monsterAni.SetInteger("behave",1);
                Chase();
                break;
            case Behavior.Attack1:
                damage = 20;
                monsterAni.SetInteger("behave",2);
                monsterAni.SetBool("attacking",true);
                break;
            case Behavior.Attack2:
                damage = 15;
                monsterAni.SetInteger("behave",3);
                monsterAni.SetBool("attacking",true);
                break;
            case Behavior.Attack3:
                damage = 0;
                monsterAni.SetInteger("behave",4);
                monsterAni.SetBool("attacking",true);
                break;
        }
        EnemyFlip();
    }

    public override void Think()
    {
        
        if (currentPattern is not null)
        {
            StopCoroutine(currentPattern);
        }
        monsterAni.SetInteger("behave",0);
        monsterAni.SetBool("attacking",false);
        var distance = Vector2.Distance(gameObject.transform.position, playerdata.transform.position);
        if (distance >=skills[0].skillMinRange && distance <= skills[0].skillMaxRange)
        {
            var skills = Random.Range(0,40);
            if (skills > 3)
            {
                behavior = Behavior.Chase;
            }
            else
            {
                behavior = Behavior.Attack2;
            }
        }
        else if (distance >=skills[1].skillMinRange && distance <= skills[1].skillMaxRange)
        {
            var skills = Random.Range(0,40);
            if (skills > 8)
            {
                behavior = Behavior.Attack1;
            }
            else
            {
                behavior = Behavior.Attack2;
            }

        }
        else if (distance >=skills[2].skillMinRange && distance <= skills[2].skillMaxRange)
        {
            var skills = Random.Range(0,40);
            if (skills > 30)
            {
                behavior = Behavior.Attack2;
            }
            else
            {
                behavior = Behavior.Attack3;
            }
        }
        else if (distance >=skills[3].skillMinRange && distance <= skills[3].skillMaxRange)
        {
            var skills = Random.Range(0,40);
            if (skills > 10)
            {
                behavior = Behavior.Attack3;
            }
            else
            {
                behavior = Behavior.Attack2;
            }
        }
        else
        {
            behavior = Behavior.Idle;
        }
    }

    public void Dash()
    {
        currentPattern = DashFlow();
        StartCoroutine(currentPattern);
    }

    public void LookAt()
    {
        currentPattern = LookFlow();
        StartCoroutine(LookFlow());
    }

    private IEnumerator LookFlow()
    {
        _lr.enabled = true;
        while (!_isDashing)
        {
            _lr.SetPosition(0,gameObject.transform.position);
            _lr.SetPosition(1,playerdata.transform.position);
            yield return null;
        }

        _lr.enabled = false;
    }

    private IEnumerator DashFlow()
    {
        _isDashing = true;
        var playerPos = playerdata.transform.position;
        while (Vector2.Distance(playerPos, gameObject.transform.position) > 0.05f)
        {
            rb.MovePosition(Vector2.MoveTowards(gameObject.transform.position,playerPos,90f*Time.deltaTime));
            yield return null;
        }
        _isDashing = false;
        yield return new WaitForSeconds(0.8f);
        Think();
    }

    public void SpawnDagger()
    {
        ObjectPooler.instance.Get(dagger,transform.position,_daggerQuaternion);
    }
}
