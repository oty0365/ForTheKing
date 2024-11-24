using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace system
{
    [CreateAssetMenu]
    public class Dialog : ScriptableObject
    {
        public Sprite faceImg;
        public string characterName;
        [TextArea]
        public string diaText;
        [Header("선택지의 여부")]
        public bool canSelect;
        public string selection1;
        public string selection2;
        public DialogNode respond1;
        public DialogNode respond2;
        [Header("우선적으로 선택할 선택지")] public bool isSelectingRight;
        [Header("퀘스트의 여부")] public bool isQuest;
        [Header("발생할 이벤트")] public UnityEvent comingEvent;
    }
}
