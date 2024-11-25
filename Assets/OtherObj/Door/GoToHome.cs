using System;
using UnityEngine;

public class GoToHome : MonoBehaviour
{
    public GameObject door;
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("player")) return;
        MapManagementSystem.instance.GoToHome();
        Destroy(door);
    }
}
