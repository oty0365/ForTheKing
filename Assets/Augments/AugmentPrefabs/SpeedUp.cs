using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponSys.One.OneScript;

public class SpeedUp : Augments
{
    public override void ActiveAugment()
    {
        OneMove.spinspeed += 20f;
    }
}
