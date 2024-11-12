using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WeponS;

public class ItemText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ItemName;

    public GameObject RandomItem;

    private WeaponArray randomitem;
    void Awake()
    {
        randomitem = RandomItem.GetComponent<WeaponArray>();
    }

    public void SetItemText()
    {
        ItemName.text = WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponname;
    }
}
