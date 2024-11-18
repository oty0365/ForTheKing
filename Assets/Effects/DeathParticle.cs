using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _prt;
    private void OnEnable()
    {
        _prt.Play();
        StartCoroutine(PrtFlow());
    }

    private IEnumerator PrtFlow()
    {
        yield return new WaitForSeconds(1.5f);
        ObjectPooler.instance.Return(gameObject);
    }
}
