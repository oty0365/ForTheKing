using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using WeponS;

public class BloodKatana : Weapon
{
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.BloodKatana).weponnumber;
        SetUpWeapon();
    }
    
    void Update()
    {
        DestructionCheck();
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("enemy")) return;
        if (other.TryGetComponent(out EnemyAi enemyAi))
        {
            PlayerStatus.instance.Hp += 5;
            PlayerStatus.instance.Hp += 5;
            if (PlayerStatus.instance.Hp >= PlayerStatus.instance.MaxHp)
            {
                PlayerStatus.instance.Hp = PlayerStatus.instance.MaxHp;
            }
            PlayerStatus.instance.setHp.Invoke();
            enemyAi.hp -= damage;
        }
    }
}
