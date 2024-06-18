using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;
using WeponS;
using Random = UnityEngine.Random;

public class WeaponArray : MonoBehaviour
{
    public int CurrentWeponIndex;
    [FormerlySerializedAs("weaponsolt1")] public GameObject weaponSolt1;
    [SerializeField] private GameObject WeaponSelectManagementSystem;
    private int _size;

    void Start()
    {
        _size = Enum.GetValues(typeof(WeaponType)).Length;
        CurrentWeponIndex = Random.Range(0, _size);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RandomWepon();
        }
    }

    public void RandomWepon()
    {
        CurrentWeponIndex = Random.Range(0, _size);
    }

    private readonly Quaternion _quaternion = Quaternion.Euler(0, 0, 90);

    public void EquipWeapon()
    {
        GameObject temp = Instantiate(WeaponData.Instance.GetWeaponData(CurrentWeponIndex).prefab,
            weaponSolt1.transform.position, Quaternion.identity, weaponSolt1.transform);
        temp.transform.localRotation = _quaternion;
        WeaponSelectManagementSystem.SetActive(false);
    }

    public void ExchangeWeapon()
    {
        Playerstatus.Gold += WeaponData.Instance.GetWeaponData(CurrentWeponIndex).value;
        WeaponSelectManagementSystem.SetActive(false);
    }
    
}