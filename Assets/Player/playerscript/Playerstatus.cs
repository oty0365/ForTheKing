using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Playerstatus : MonoBehaviour
{
    public static float Hp;
    public static float Gold;
    [SerializeField] private Slider playerhpveiw;
    public float damageamount;
    public bool isinfinate;
    public int gotdamge;
    public float infinatetime;
    void Start()
    {
        Hp = 100f;
        Gold = 0;
        playerhpveiw.value = Hp;
        isinfinate = false;
        gotdamge = 0;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (gotdamge!=0 && !isinfinate)
        {
            HpDecrease();
        }
        
    }

    public void HpDecrease()
    {
        if (Hp > 0)
        {
            Hp -= damageamount;
            StopAllCoroutines();
            StartCoroutine(ChangeHealth(Hp));
        }
        else
        {
#if UNITY_EDITOR || UNITY_EDITOR_64 || UNITY_EDITOR_WIN
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    IEnumerator ChangeHealth(float health)
    {
        isinfinate = true;
        for (float i = 0; i < 0.3f; i += Time.deltaTime)
        {
            playerhpveiw.value = Mathf.Lerp(playerhpveiw.value, health, 2 * Time.deltaTime);
            yield return null;
        }
        playerhpveiw.value = health;
        yield return new WaitForSeconds(infinatetime);
        isinfinate = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("enemy"))
        {
            gotdamge++;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("enemy"))
        {
            gotdamge--;
        }
    }
    
    
}