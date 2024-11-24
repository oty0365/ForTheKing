using System.Collections.Generic;
using UnityEngine;

namespace system
{
        [CreateAssetMenu]
        public class DialogNode:ScriptableObject
        {
            [Header("현재 대화")] public Dialog[] dialogs;
        }

}