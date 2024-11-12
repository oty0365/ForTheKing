using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AugmentsManager : MonoBehaviour
{
    public static AugmentsManager instance;
    public Augments[] augments;
    public int _currentWeaponIndex;
    
    private void Awake()
    {
        instance = this;
    }

    public void RandomAugment()
    {
        _currentWeaponIndex = Random.Range(0, augments.Length);
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
