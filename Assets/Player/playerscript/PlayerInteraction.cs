using System;
using System.Collections;
using System.Collections.Generic;
using System.Pause;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool isinteractingwithbox;
    private bool isActived;
    private GameObject gatcha;

    private void Awake()
    {
        gatcha = GameObject.FindWithTag("gatcha");
    }

    // Start is called before the first frame update
    void Start()
    {
        isActived = false;
        isinteractingwithbox = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActived && isinteractingwithbox && Input.GetKeyDown(KeyCode.F))
        {
                    gatcha.SetActive(true);
                    ItemPanelManager.selectionTime.Invoke();

        }
        isActived = gatcha.activeSelf;
    }

    private void OnTriggerEnter2D(Collider2D playercolider)
    {
        if (playercolider.gameObject.CompareTag("lootchest"))
        {
            Interaction.interactedBox = playercolider.gameObject;
            isinteractingwithbox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D playercolider)
    {
        if (playercolider.gameObject.CompareTag("lootchest"))
        {
            isinteractingwithbox = false;
        }
    }
}
