using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WeponS;

public class ItemRarity : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemrarity;

    public GameObject RandomItem;

    private WeaponArray randomitem;
    void Awake()
    {
        randomitem = RandomItem.GetComponent<WeaponArray>();
    }
    
    public void SetWeaponItemRarity()
    {
        switch (WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponrarity)
        {
            case Rarity.Common:
                itemrarity.color = Color.cyan;
                break;
            case Rarity.Rare:
                itemrarity.color =Color.green;
                break;
            case Rarity.Epic:
                itemrarity.color = Color.magenta;
                break;
            case Rarity.Legendary:
                itemrarity.color = Color.yellow;
                break;
            case Rarity.Unknown:
                itemrarity.color = Color.red;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        itemrarity.text = WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponrarity.ToName();

        Rarity.Common.ToName();
    }
}
