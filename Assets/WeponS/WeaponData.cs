using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace WeponS
{
    public class WeaponData : MonoBehaviour
    {
        public static WeaponData Instance;

         public NearWepon[] weapons;
        [HideInInspector] public bool[] toggled;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public NearWepon GetWeaponData(WeaponType type) => weapons[(int)type];

        public NearWepon GetWeaponData(int idx) => weapons[idx];
    }
}