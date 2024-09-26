using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;

public class Katana : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.Katana).weponnumber;
        SetUpWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        DestructionCheck();
    }
}
