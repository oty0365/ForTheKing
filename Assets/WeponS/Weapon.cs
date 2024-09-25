using UnityEngine;

namespace WeponS
{
    public class Weapon : MonoBehaviour
    {
        protected bool canDestroy;
        protected float damage;
        [SerializeField] protected int weaponTag;

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
    }
}
