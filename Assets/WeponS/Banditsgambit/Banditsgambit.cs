using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;

public class BanditsGambit : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        SetUpWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        DestructionCheck();
    }
}
