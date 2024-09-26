using System.Collections;
using System.Collections.Generic;
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
}
