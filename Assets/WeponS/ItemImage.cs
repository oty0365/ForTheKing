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

    public WeaponArray randomitem;
    void Awake()
    {
        randomitem = RandomItem.GetComponent<WeaponArray>();
    }
    public void SetItemImage()
    {
        Itmeimage.sprite = WeaponData.Instance.GetWeaponData(randomitem.CurrentWeponIndex).weponimage;
    }
}
