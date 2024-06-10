using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WeponS;

public class Itemdmgamt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemdmgamt;

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
        itemdmgamt.text = WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).wepondamage.ToString();
    }
}
