using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AugmentsDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI augmentName;

    public GameObject augment;

    private AugmentsUi augmentsUi;
    void Awake()
    {
        augmentsUi = augment.GetComponent<AugmentsUi>();
    }

    public void SetAugmentDescription()
    {
        augmentName.text = augmentsUi.augmentsManager.augments[augmentsUi.augmentsManager._currentWeaponIndex].description;
    }
}
