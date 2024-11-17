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
        private Animator _animator;
        public AnimationClip[] originalClips;
        public AnimationClip[] animationClips;
        private AnimatorOverrideController _overrideController;
        private SpriteRenderer _sr;
        public bool isLegend;
        protected void SetUpWeapon()
        {
            canDestroy = false;
            damage = WeaponData.Instance.GetWeaponData(weaponTag).wepondamage;
            _sr = GetComponent<SpriteRenderer>();
            _sr.sortingOrder = 5;
        }

        protected void SetUpLegendaryWeapon()
        {
            isLegend = true;
            _animator = GameObject.FindWithTag("player").GetComponent<Animator>();
            _overrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
            _animator.runtimeAnimatorController = _overrideController;
            ChangeAnimation("playeridle",animationClips[0]);
            ChangeAnimation("playerrun",animationClips[1]);
            
        }

        protected void ChangeAnimation(string stateName,AnimationClip clip)
        {
            _overrideController[stateName] = clip;
        }

        protected void OriginAnimation(string stateName, AnimationClip clip)
        {
            _overrideController[stateName] = clip;
        }
        

        protected virtual void DestructionCheck()
        {
            if (canDestroy)
            {
                if (isLegend)
                {
                    OriginAnimation("playeridle",originalClips[0]);
                    OriginAnimation("playerrun",originalClips[1]);
                }
                Destroy(gameObject);
            }
        }
       public virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("enemy")) return;
            if (other.TryGetComponent(out EnemyAi enemyAi))
            {
                enemyAi.hp -= damage+PlayerStatus.AttakDmg;
            }
        }
    }
}
