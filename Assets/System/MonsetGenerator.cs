using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;
using Screen = UnityEngine.Device.Screen;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject[] SpwanArray;
    public float spawnTime;
    private Camera _camera;
    public static Action startSpawnMonsters;
    public static Action<float> decreaseSpawningDuration;

    private void Awake()
    {
        startSpawnMonsters = StartSpawnMonsters;
        decreaseSpawningDuration = DecreaseSpawningDuration;
    }

    void Start()
    {
        _camera = GetComponent<Camera>();

    }

    public void DecreaseSpawningDuration(float value)
    {
        spawnTime -= value;
        if (spawnTime <= 0)
        {
            spawnTime = 0.1f;
        }
    }

    public void StartSpawnMonsters()
    {
        StartCoroutine(SpawnFlow());
    }
    
    private IEnumerator SpawnFlow()
    {
        if(Time.timeScale!=0){
        yield return new WaitForSeconds(spawnTime);
        var _spwanDir = Random.Range(0, 4);
        switch (_spwanDir)
        {
            case 3:
            {
                var _spwanPos = _camera.ScreenToWorldPoint(new Vector2(Random.Range(-1 * Screen.width, Screen.width),
                    -1 * Screen.height));
                var _spwaningMonster = SpwanArray[Random.Range(0, SpwanArray.Length)];
                ObjectPooler.instance.Get(_spwaningMonster, _spwanPos, Quaternion.identity);
                break;
            }
            case 2:
            {
                var _spwanPos = _camera.ScreenToWorldPoint(new Vector2(-1 * Screen.width,
                    Random.Range(-1 * Screen.height, Screen.height)));
                var _spwaningMonster = SpwanArray[Random.Range(0, SpwanArray.Length)];
                ObjectPooler.instance.Get(_spwaningMonster, _spwanPos, Quaternion.identity);
                break;
            }
            case 1:
            {
                var _spwanPos =
                    _camera.ScreenToWorldPoint(new Vector2(Screen.width,
                        Random.Range(-1 * Screen.height, Screen.height)));
                var _spwaningMonster = SpwanArray[Random.Range(0, SpwanArray.Length)];
                ObjectPooler.instance.Get(_spwaningMonster, _spwanPos, Quaternion.identity);
                break;
            }
            case 0:
            {
                var _spwanPos =
                    _camera.ScreenToWorldPoint(
                        new Vector2(Random.Range(-1 * Screen.width, Screen.width), Screen.height));
                var _spwaningMonster = SpwanArray[Random.Range(0, SpwanArray.Length)];
                ObjectPooler.instance.Get(_spwaningMonster, _spwanPos, Quaternion.identity);
                break;
            }
        }
        }

        StartCoroutine(SpawnFlow());

    }
}
