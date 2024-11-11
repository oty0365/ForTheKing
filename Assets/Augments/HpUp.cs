using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUp : Augments
{
    public override void ActiveAugment()
    {
        PlayerStatus.Hp += 15;
    }
}
