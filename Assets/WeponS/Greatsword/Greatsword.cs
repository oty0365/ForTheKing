using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;
using WeponSys.One.OneScript;

public class GreatSword : Weapon
{
    private float _original;
    // Start is called before the first frame update
    void Start()
    {
        weaponTag = WeaponData.Instance.GetWeaponData(WeaponType.GreatSword).weponnumber;
        _original = OneMove.spinspeed;
        OneMove.spinspeed *=0.6f;
        SetUpWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        DestructionCheck();
    }
    protected override void DestructionCheck()
    {
        if (canDestroy)
        {
            if (isLegend)
            {
                OriginAnimation("playeridle",originalClips[0]);
                OriginAnimation("playerrun",originalClips[1]);
            }

            OneMove.spinspeed = _original;
            Destroy(gameObject);
        }
    }
}
