using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;

public class KnightsSword : Weapon
{
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.KnightSword).weponnumber;
        SetUpWeapon();
    }
    
    void Update()
    {
        DestructionCheck();
    }
}
