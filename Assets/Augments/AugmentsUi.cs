using System;
using System.Collections;
using System.Collections.Generic;
using System.Pause;
using UnityEngine;
using Random = UnityEngine.Random;

public class AugmentsUi : MonoBehaviour
{
    //public AugmentsManager augmentsManager;
    public GameObject augmentSelectionModel;
    public int currentIndex;
    private void Awake()
    {
        //augmentsManager = GameObject.FindWithTag("augments").GetComponent<AugmentsManager>();
        RandomAugment();
    }

    public void RandomAugment()
    {
        currentIndex = Random.Range(0, AugmentsManager.instance.augments.Length);
    }

    public void OnSelect()
    {
        AugmentsManager.instance.augments[currentIndex].ActiveAugment();
        PlayerStatus.Exp -=PlayerStatus.MaxExp;
        PlayerStatus.setExp.Invoke();
        augmentSelectionModel.SetActive(false);
    }
}
