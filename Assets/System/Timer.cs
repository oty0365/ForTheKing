using System.Collections;
using TMPro;
using UnityEngine;

namespace System
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timer;
        [SerializeField] private float time;
        public static Action gameStart;
        void Start()
        {
            gameStart = GameStart;
            gameStart.Invoke();
        }

        private void GameStart()
        {
            StartCoroutine(GameFlow());
            MonsterGenerator.startSpawnMonsters.Invoke();
        }

        private IEnumerator GameFlow()
        {
            var t = time;
            for (var i = time; i >= 0; i -= Time.deltaTime)
            {
                if (t - i >= 5)
                {
                    t = i;
                    MonsterGenerator.decreaseSpawningDuration.Invoke(0.5f);
                }
                timer.text = ((int)i).ToString();
                
                yield return null;
            }
            CompleteGame();
        }

        private void CompleteGame()
        {
            Debug.Log("!");
        }
    }
}
