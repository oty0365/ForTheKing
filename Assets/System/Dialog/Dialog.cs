using UnityEngine;

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
        [Header("우선적으로 선택할 선택지")] public bool isSelectingRight;
        [Header("퀘스트의 여부")] public bool isQuest;
    }
}
