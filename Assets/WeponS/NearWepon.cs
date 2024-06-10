using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeponS;

[Serializable]
public class NearWepon
{
    public string weponname;
    public float wepondamage;
    public int weponnumber;
    public Rarity weponrarity;
    [TextArea] public string wepondiscription;
    public Sprite weponimage;
    public GameObject prefab;
    public int value;

}
