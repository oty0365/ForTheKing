using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gamepause : MonoBehaviour
{
    [NonSerialized]public bool ispaused;

    [SerializeField] private GameObject isselecting;
    // Start is called before the first frame update
    void Start()
    {
        ispaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ispaused = !ispaused;
        }
        Time.timeScale = isselecting.activeSelf || ispaused ? 0 : 1;
    }
}
