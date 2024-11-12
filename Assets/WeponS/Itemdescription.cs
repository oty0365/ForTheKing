using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WeponS;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemdescription;

    public GameObject RandomItem;

    private WeaponArray randomitem;
    // Start is called before the first frame update
    void Awake()
    {
        randomitem = RandomItem.GetComponent<WeaponArray>();
    }

    // Update is called once per frame
    public void SetItemDescriptions()
    {
        itemdescription.text = WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).wepondiscription;
    }
}
