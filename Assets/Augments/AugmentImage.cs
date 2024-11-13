using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AugmentImage : MonoBehaviour
{
    [SerializeField] private Image augmentName;

    public GameObject augment;

    private AugmentsUi augmentsUi;
    void Awake()
    {
        augmentsUi = augment.GetComponent<AugmentsUi>();
    }

    public void SetAugmentImage()
    {
        augmentName.sprite = AugmentsManager.instance.augments[augmentsUi.currentIndex].sprite;
    }
}
