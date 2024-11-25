using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skill
{
    [Header("스킬이름")] public string skillName;
    [Header("스킬 시전 가능 범위(최대)")] public float skillMaxRange;
    [Header("스킬 시전 가능 범위(최소)")] public float skillMinRange;
}

public class BossAi : EnemyAi
{

    public Slider bossHpView;
    public string bossName;
    public TextMeshProUGUI bossNameView;
    protected string previousSkill;
    protected string currentSkill;
    protected int skillStack;
    public Skill[] skills;
    protected Rigidbody2D rb;

    protected void SetUpBoss()
    {
        SetUpEnemy();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Chase()
    {
        rb.MovePosition(transform.position = Vector3.MoveTowards(gameObject.transform.position, playerdata.transform.position, movespeed*Time.deltaTime));
    }

    protected bool SkillStackCheck(int idx)
    {
        currentSkill = skills[idx].skillName;
        if (previousSkill == currentSkill)
        {
            skillStack++;
        }
        else
        {
            skillStack = 0;
            return true;
        }

        return skillStack < 3;
    }
}
