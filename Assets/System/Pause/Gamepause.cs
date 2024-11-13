using UnityEngine;

namespace System.Pause
{
    public class Gamepause : MonoBehaviour
    {
        [NonSerialized]public bool ispaused;
        [SerializeField] private GameObject isaugmenting;
        [SerializeField] private GameObject isselecting;
        public static Action pauseGame;
        public static Action startGame;
        void Start()
        {
            ispaused = false;
            pauseGame = GamePause;
            startGame = GameStart;
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ispaused = !ispaused;
            }
            //Time.timeScale = isselecting.activeSelf || ispaused ? 0 : 1;
        }

        public void GamePause()
        {
            Time.timeScale = 0;
        }

        public void GameStart()
        {
            Time.timeScale = 1;
        }
    }
}
