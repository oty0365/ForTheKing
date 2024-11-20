using System.Collections;
using Enemies;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace System
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timer;
        [SerializeField] private float time;
        public static Action gameStart;
        public GameObject door;
        private GameObject _player;
        void Start()
        {
            gameStart = GameStart;
            gameStart.Invoke();
            _player = GameObject.FindWithTag("player");
        }

        private void GameStart()
        {
            time = MapManagementSystem.instance.mapData[MapManagementSystem.instance.currentMapIndex].playTime;
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
            //_tr.enabled = false;
            _player.transform.position = new Vector3(0, -3);
            //_tr.enabled = true;
            MonsterGenerator.keepGenerate = false;
            Instantiate(door, new Vector2(0, 3), Quaternion.identity);
            yield return null;
        }
    }
}
