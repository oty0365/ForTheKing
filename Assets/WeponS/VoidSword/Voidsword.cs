using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;

public class VoidSword : Weapon
{
    
    // Start is called before the first frame update
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.VoidLongSword).weponnumber;
        SetUpWeapon();
        SetUpLegendaryWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        DestructionCheck();
    }
}
