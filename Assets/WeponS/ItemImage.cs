using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using WeponS;

public class ItemImage : MonoBehaviour
{
    [SerializeField] private Image Itmeimage;

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
        Itmeimage.sprite = WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponimage;
    }
}
