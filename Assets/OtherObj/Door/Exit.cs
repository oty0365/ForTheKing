using System;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject door;
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("player")) return;
        MapManagementSystem.instance.GoToNext();
        Destroy(door);
    }
}
