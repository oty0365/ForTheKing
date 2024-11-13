using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WeponS;

public class AugmentName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI augmentName;

    public GameObject augment;

    private AugmentsUi augmentsUi;
    void Awake()
    {
        augmentsUi = augment.GetComponent<AugmentsUi>();
    }

    public void SetAugmentName()
    {
        augmentName.text = AugmentsManager.instance.augments[augmentsUi.currentIndex].augmentName;
    }
}
