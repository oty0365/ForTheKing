using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool isinteractingwithbox;
    public GameObject arrayweapon1;
    public GameObject arrayweapon2;
    public GameObject arrayweapon3;
    public GameObject gatcha;

    private WeaponArray _weaponArray1;
    private WeaponArray _weaponArray3;
    private WeaponArray _weaponArray2;
    // Start is called before the first frame update
    void Start()
    {
        isinteractingwithbox = false; 
        gatcha.SetActive(false);
        _weaponArray1 = arrayweapon1.GetComponent<WeaponArray>();
        _weaponArray2 = arrayweapon2.GetComponent<WeaponArray>();
        _weaponArray3 = arrayweapon3.GetComponent<WeaponArray>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isinteractingwithbox)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _weaponArray1.RandomWepon();
                _weaponArray2.RandomWepon();
                _weaponArray3.RandomWepon();
               gatcha.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D playercolider)
    {
        if (playercolider.gameObject.CompareTag("lootchest"))
        {
            isinteractingwithbox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D playercolider)
    {
        isinteractingwithbox = false;
    }
}
