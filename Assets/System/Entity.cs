using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace System
{
    public class Entity : MonoBehaviour
    {
        public float hp;
        public Effect effect;
        public List<Effect> effects = new();
        public float movespeed;
        public void StatusCheck()
        {
            switch (effect)
            {
                
                case Effect.Stun:
                    StartCoroutine(StunFlow());
                    effects.Add(effect);
                    effect = Effect.Normal;
                    break;
                case Effect.Poison:
                    StartCoroutine(PoisonFlow());
                    effects.Add(effect);
                    effect = Effect.Normal;
                    break;
            }
        }

        public IEnumerator StunFlow()
        {
            if (effects.Contains(Effect.Stun))
            {
                effects.Remove(Effect.Stun);
                yield break;
            }
            var curmove = movespeed;
            movespeed = 0;
            yield return new WaitForSeconds(1.6f);
            movespeed = curmove;
            effects.Remove(Effect.Stun);
        }

        protected IEnumerator PoisonFlow()
        {
            if (effects.Contains(Effect.Poison))
            {
                effects.Remove(Effect.Poison);
                yield break;
            }
            for (var i = 0f; i < 2f; i += Time.deltaTime)
            {
                hp -= hp / 6*Time.deltaTime;
                yield return null;
            }
            effects.Remove(Effect.Poison);
        }
        
    }
}
