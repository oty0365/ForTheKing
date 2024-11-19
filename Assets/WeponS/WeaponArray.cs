using System;
using System.Collections;
using System.Collections.Generic;
using System.Pause;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;
using WeponS;
using Random = UnityEngine.Random;

public class WeaponArray : MonoBehaviour
{
    public int CurrentWeponIndex;
    private int _equiptedWaepon;
    private GameObject _core;
    [FormerlySerializedAs("weaponsolt1")] public GameObject weaponSolt1;
    [SerializeField] private GameObject WeaponSelectManagementSystem;
    private int _size;

    void Awake()
    {
        _core = GameObject.FindWithTag("core");
        _size = Enum.GetValues(typeof(WeaponType)).Length;
        CurrentWeponIndex = Random.Range(0, _size);
    }

    public void RandomWeapon()
    {
        CurrentWeponIndex = Random.Range(0, _size);
    }

    private readonly Quaternion _quaternion = Quaternion.Euler(0, 0, 90);

    public void EquipWeapon()
    {
        if (_core.transform.GetChild(0).childCount>0)
        {
            var ex = _core.transform.GetChild(0).GetChild(0);
            var wp = ex.GetComponent<Weapon>();
            var val = wp.weaponTag;
            PlayerStatus.instance.weaponList.Remove(wp.gameObject);
            wp.canDestroy = true;
            PlayerStatus.instance.Gold += WeaponData.Instance.GetWeaponData(val).value;
            GameObject temp = Instantiate(WeaponData.Instance.GetWeaponData(CurrentWeponIndex).prefab,
                weaponSolt1.transform.position, Quaternion.identity, weaponSolt1.transform);
            temp.transform.localRotation = _quaternion;
            PlayerStatus.instance.weaponList.Add(temp);
            Gamepause.startGame.Invoke();
            WeaponSelectManagementSystem.SetActive(false);
            _equiptedWaepon = CurrentWeponIndex; 
            Destroy(Interaction.interactedBox);
        }
        else
        {
            GameObject temp = Instantiate(WeaponData.Instance.GetWeaponData(CurrentWeponIndex).prefab,
                weaponSolt1.transform.position, Quaternion.identity, weaponSolt1.transform);
            temp.transform.localRotation = _quaternion;
            Gamepause.startGame.Invoke();
            WeaponSelectManagementSystem.SetActive(false);
            _equiptedWaepon = CurrentWeponIndex; 
            Destroy(Interaction.interactedBox);
        }

    }

    public void ExchangeWeapon()
    {
        PlayerStatus.instance.Gold += WeaponData.Instance.GetWeaponData(CurrentWeponIndex).value;
        Gamepause.startGame.Invoke();
        WeaponSelectManagementSystem.SetActive(false);
        Destroy(Interaction.interactedBox);
    }
    
}