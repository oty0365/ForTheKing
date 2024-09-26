using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;

public class VampireTooth : Weapon
{
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.VampireTeeth).weponnumber;
        SetUpWeapon();
    }
    
    void Update()
    {
        DestructionCheck();
    }
}
