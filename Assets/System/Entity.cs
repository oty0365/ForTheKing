using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace System
{
    public class Entity : MonoBehaviour
    {
        public Effect effect;
        public List<Effect> effects = new();
        public float movespeed;
        public void StatusCheck()
        {
            switch (effect)
            {
                case Effect.Stun:
                    effects.Add(effect);
                    effect = Effect.Normal;
                    StartCoroutine(StunFlow());
                    break;
            }
        }

        public IEnumerator StunFlow()
        {
            var curmove = movespeed;
            movespeed = 0;
            yield return new WaitForSeconds(1.6f);
            movespeed = curmove;
        }
    }
}
