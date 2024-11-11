using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using Unity.VisualScripting;
using UnityEngine;
using WeponS;

public class SwampKnife : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.SwampKnife).weponnumber;
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
                enemyAi.hp -= damage;
                enemyAi.effect = Effect.Poison;
            }
    }

}
