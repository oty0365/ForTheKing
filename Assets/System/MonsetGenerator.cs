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
    void Start()
    {
        _camera = GetComponent<Camera>();
        StartCoroutine(SpawnFlow());
        
    }
    
    private IEnumerator SpawnFlow()
    {
        yield return new WaitForSeconds(spawnTime);
        var _spwanDir = Random.Range(0, 4);
        switch (_spwanDir)
        {
            case 3:
            {
                var _spwanPos = _camera.ScreenToWorldPoint(new Vector2(Random.Range(-1*Screen.width,Screen.width),-1*Screen.height));
                var _spwaningMonster = SpwanArray[Random.Range(0, SpwanArray.Length)];
                ObjectPooler.instance.Get(_spwaningMonster.name,_spwaningMonster,_spwanPos,Quaternion.identity);
                break;
            }
            case 2:
            {
                var _spwanPos = _camera.ScreenToWorldPoint(new Vector2(-1*Screen.width,Random.Range(-1*Screen.height,Screen.height)));
                var _spwaningMonster = Random.Range(0, SpwanArray.Length);
                Instantiate(SpwanArray[_spwaningMonster], _spwanPos, Quaternion.identity);
                break;
            }
            case 1:
            {
                var _spwanPos = _camera.ScreenToWorldPoint(new Vector2(Screen.width,Random.Range(-1*Screen.height,Screen.height)));
                var _spwaningMonster = Random.Range(0, SpwanArray.Length);
                Instantiate(SpwanArray[_spwaningMonster], _spwanPos, Quaternion.identity);
                break;
            }
            case 0:
            {
                var _spwanPos = _camera.ScreenToWorldPoint(new Vector2(Random.Range(-1*Screen.width,Screen.width),Screen.height));
                var _spwaningMonster = Random.Range(0, SpwanArray.Length);
                Instantiate(SpwanArray[_spwaningMonster], _spwanPos, Quaternion.identity);
                break;
            }
        }

        StartCoroutine(SpawnFlow());

    }
}
