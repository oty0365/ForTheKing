using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;

public class Dagger : Weapon
{
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.ShortSword).weponnumber;
        SetUpWeapon();
    }
    
    void Update()
    {
        DestructionCheck();
    }
}
