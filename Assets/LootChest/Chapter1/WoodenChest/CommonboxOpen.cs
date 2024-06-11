using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CommonboxOpen : MonoBehaviour
{
    public bool isinteracting;
    // Start is called before the first frame update
    void Start()
    {
        isinteracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isinteracting)
        {
            
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("player"))
        {
            isinteracting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("player"))
        {
            isinteracting = false;
        }
    }
}
