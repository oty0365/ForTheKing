using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WeponS;

public class ItemValue : MonoBehaviour
{
    private TextMeshProUGUI itemvalue;
    public GameObject RandomItem;

    private WeaponArray randomitem;
    // Start is called before the first frame update
    private void Awake()
    {
        itemvalue = GetComponent<TextMeshProUGUI>();
        randomitem = RandomItem.GetComponent<WeaponArray>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    /*void Update()
    {
        itemvalue.text = $"{WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).value}$";
    }*/

    public void SetItemValue()
    {
        itemvalue.text = $"{WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).value}$";
    }
}
