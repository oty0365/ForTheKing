using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;

public class DamageUp : Augments
{
    public override void ActiveAugment()
    {
        PlayerStatus.AttakDmg += 15;
    }
}
