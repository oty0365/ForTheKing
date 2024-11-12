using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AugmentsUi : MonoBehaviour
{
    public AugmentsManager augmentsManager;
    public int currentIndex;
    private void Awake()
    {
        augmentsManager = GameObject.FindWithTag("augments").GetComponent<AugmentsManager>();
    }

    public void RandomAugment()
    {
        currentIndex = Random.Range(0, augmentsManager.augments.Length);
    }
}
