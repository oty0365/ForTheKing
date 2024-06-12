using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinAI : MonoBehaviour
{
    [SerializeField] private GameObject playerdata;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector3.MoveTowards(gameObject.transform.position, playerdata.transform.position, 2*Time.deltaTime);
    }
}
