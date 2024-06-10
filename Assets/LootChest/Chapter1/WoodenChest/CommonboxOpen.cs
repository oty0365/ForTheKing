using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CommonboxOpen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { ;
    
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("player"))
        {
            Debug.Log("!");
        }
    }
}
