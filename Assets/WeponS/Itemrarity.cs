using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WeponS;

public class Itemrarity : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemrarity;

    public GameObject RandomItem;

    private WeaponArray randomitem;
    // Start is called before the first frame update
    void Start()
    {
        randomitem = RandomItem.GetComponent<WeaponArray>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponrarity == Rarity.Common)
        {
            itemrarity.color = Color.cyan;
        }
        else if (WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponrarity == Rarity.Rare)
        {
            itemrarity.color = Color.green;
        }
        else if (WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponrarity == Rarity.Epic)
        {
            itemrarity.color = Color.magenta;
        }
        else if (WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponrarity == Rarity.Legendary)
        {
            itemrarity.color = Color.yellow;
        }
        else if (WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponrarity == Rarity.Unknown)
        {
            itemrarity.color = Color.red;
        }
        itemrarity.text = WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponrarity.ToName();

        Rarity.Common.ToName();
    }
}
