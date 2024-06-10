using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WeponS;

public class Itemvalue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemvalue;

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
        itemvalue.text = $"{WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).value}$";
    }
}
