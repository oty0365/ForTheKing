using UnityEngine;

namespace Npc.Nun
{
    public class NunBehavior : MonoBehaviour
    {
        public void FullHeal()
        {
            PlayerStatus.instance.fullHp.Invoke();
        }
    }
}
