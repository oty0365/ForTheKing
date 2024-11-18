using System.Collections;
using Enemies;
using TMPro;
using UnityEngine;

namespace System
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timer;
        [SerializeField] private float time;
        public static Action gameStart;
        private GameObject _player;
        private TrailRenderer _tr;
        void Start()
        {
            gameStart = GameStart;
            gameStart.Invoke();
            _player = GameObject.FindWithTag("player");
            _tr = _player.GetComponentInChildren<TrailRenderer>();
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
            StartCoroutine(EndGameFlow());
        }

        private IEnumerator EndGameFlow()
        {
            _tr.enabled = false;
            _player.transform.position = new Vector3(0, 0);
            _tr.enabled = true;
            MonsterGenerator.keepGenerate = false;
            for (var i = 0f; i <= 3f; i += Time.deltaTime)
            {
                _player.transform.position = new Vector3(0, 0);
                yield return null;
            }
        }
    }
}
