using System.Collections;
using UnityEngine;
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
        var _spwanDir = Random.Range(0, 2);
        if (_spwanDir == 1)
        {
            var _spwanPos = _camera.ScreenToWorldPoint(new Vector2(Screen.width,Random.Range(-1*Screen.height,Screen.height)));
            var _spwaningMonster = Random.Range(0, SpwanArray.Length);
            Instantiate(SpwanArray[_spwaningMonster], _spwanPos, Quaternion.identity);
        }
        if (_spwanDir == 1)
        {
            var _spwanPos = _camera.ScreenToWorldPoint(new Vector2(Random.Range(-1*Screen.width,Screen.width),Screen.height));
            var _spwaningMonster = Random.Range(0, SpwanArray.Length);
            Instantiate(SpwanArray[_spwaningMonster], _spwanPos, Quaternion.identity);
        }

        StartCoroutine(SpawnFlow());

    }
}
