using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;

public class WoodenSword : Weapon
{
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.WoodenSword).weponnumber;
        SetUpWeapon();
    }
    void Update()
    {
        DestructionCheck();
    }
}
