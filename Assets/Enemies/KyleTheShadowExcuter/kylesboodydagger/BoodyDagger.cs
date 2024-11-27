using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoodyDagger : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    public float speed;
    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb2D.velocity = gameObject.transform.right* speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall"))
        {
            ObjectPooler.instance.Return(gameObject);
        }
    }
}
