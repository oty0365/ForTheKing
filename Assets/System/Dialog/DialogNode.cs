using UnityEngine;

namespace system
{

    [System.Serializable]
    public class DialogNode
    {
        [Header("현재 대화")]
        public Dialog dialogs;
        [Header("후속 대화")]
        public DialogNode[] child;
    }
}
