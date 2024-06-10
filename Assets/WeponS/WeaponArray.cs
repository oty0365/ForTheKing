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
    public GameObject weaponsolt1;

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
        CurrentWeponIndex = Random.Range(0,_size);
    }

    private readonly Quaternion _quaternion = Quaternion.Euler(0, 0, 90);
    
    public void EquipWeapon()
    {
        GameObject temp = Instantiate(WeaponData.Instance.GetWeaponData(CurrentWeponIndex).prefab, weaponsolt1.transform.position, Quaternion.identity, weaponsolt1.transform);
        temp.transform.localRotation = _quaternion;
    }
}
