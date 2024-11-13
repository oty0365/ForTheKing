using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponSys.One.OneScript;

public class RandomDice : Augments
{
    public override void ActiveAugment()
    {
        AugmentsManager.instance.augments[Random.Range(0,AugmentsManager.instance.augments.Length)].ActiveAugment();
    }
}
