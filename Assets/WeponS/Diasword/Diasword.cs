using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;

public class DiaSword : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.DiamondSword).weponnumber;
        SetUpWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        DestructionCheck();
    }
}
