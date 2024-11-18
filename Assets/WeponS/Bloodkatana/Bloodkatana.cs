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
            PlayerStatus.Hp += 5;
            if (PlayerStatus.Hp >= PlayerStatus.MaxHp)
            {
                PlayerStatus.Hp = PlayerStatus.MaxHp;
            }
            PlayerStatus.setHp.Invoke();
            enemyAi.hp -= damage;
        }
    }
}
