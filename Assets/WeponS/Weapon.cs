using System;
using Enemies;
using UnityEngine;

namespace WeponS
{
    public class Weapon : MonoBehaviour
    {
        public bool canDestroy;
        protected float damage;
        public int weaponTag;

        protected void SetUpWeapon()
        {
            canDestroy = false;
            damage = WeaponData.Instance.GetWeaponData(weaponTag).wepondamage;
        }

        protected void DestructionCheck()
        {
            if (canDestroy)
            {
                Destroy(gameObject);
            }
        }
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("enemy"))
            {
                other.GetComponent<EnemyAi>().hp -= damage;
            }
        }
    }
}
