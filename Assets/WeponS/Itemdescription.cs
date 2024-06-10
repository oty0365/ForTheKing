using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WeponS;

public class Itemdescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemdescription;

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
        itemdescription.text = WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).wepondiscription;
    }
}
