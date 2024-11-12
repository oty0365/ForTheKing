using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WeponS;

public class AugmentName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI augmentName;

    public GameObject randomAugment;

    private WeaponArray randomitem;
    void Start()
    {
        randomitem = randomAugment.GetComponent<WeaponArray>();
    }
    
    void OnEnable()
    {
        augmentName.text = WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponname;
    }
}
