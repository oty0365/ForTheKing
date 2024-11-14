using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponSys.One.OneScript;

public class FullHp : Augments
{
    public override void ActiveAugment()
    {
        PlayerStatus.fullHp.Invoke();
    }
}
