using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using WeponS;

public class BanditsGambit : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.Bandit).weponnumber;
        SetUpWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        DestructionCheck();
    }
    
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("enemy")) return;
        if (other.TryGetComponent(out EnemyAi enemyAi))
        {
            PlayerStatus.instance.Gold += 5;
            enemyAi.hp -= damage;
        }
    }
}
