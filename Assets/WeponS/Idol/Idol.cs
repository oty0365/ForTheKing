using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;

public class Idol : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.Idol).weponnumber;
        SetUpWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        DestructionCheck();
    }
}
