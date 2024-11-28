using System;
using System.Collections;
using System.Collections.Generic;
using System.Pause;
using Enemies;
using Player.playerscript;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;
    public float Hp;
    public float MaxHp=100;
    public float Gold;
    public float Exp;
    public float MaxExp=50;
    public float AttakDmg = 0;
    [SerializeField] private Slider playerhpveiw;
    [SerializeField] private Slider playerexpveiw;
    public float damageamount;
    public bool isinfinate;
    public int gotdamge;
    public float infinatetime;
    private bool _isActive;
    private GameObject _augmentSelect;
    private bool _isSelecting;
    public Action setExp;
    public Action hpUp;
    public Action fullHp;
    public Action setHp;
    public List<GameObject> weaponList;
    private IEnumerator _hpDecrease;
    public LayerMask enemyHitBox;
    public Transform playerCore;
    private void Awake()
    {
        instance = this;
        weaponList = new List<GameObject>();
        _augmentSelect = GameObject.FindWithTag("augmentsui");
    }

    void Start()
    {
        Hp = MaxHp;
        Exp = 0f;
        Gold = 0;
        _isActive = false;
        _isSelecting = false;
        playerhpveiw.value = MaxHp;
        playerexpveiw.maxValue = MaxExp;
        playerexpveiw.value = Exp;
        isinfinate = false;
        gotdamge = 0;
        setExp = SetExp;
        hpUp = HpUp;
        fullHp = FullHp;
        setHp = SetHp;
    }
    private void Update()
    {
        ExpCheck();
    }

    private void FixedUpdate()
    {
        var cols = Physics2D.OverlapCircleAll(playerCore.transform.position, 1f);
        foreach (var col in cols)
        {
            if (col.CompareTag("enemyhitbox") && !isinfinate)
            {
                damageamount = col.transform.parent.GetComponent<EnemyAi>().damage;
                Hp -= damageamount;
                HpDecrease();
            }
        }
    }

    private void ExpCheck()
    {
        if (!_isSelecting&&Exp >= MaxExp)
        {
            _augmentSelect.SetActive(true);
            AugmentPanelManager.selectionTime.Invoke();
            var origin = Exp-MaxExp;
            MaxExp *= 2;
            playerexpveiw.maxValue = MaxExp;
            Exp = origin;
            SetExp();
        }

        if (_augmentSelect.activeSelf)
        {
            _isSelecting = true;
        }
        else
        {
            _isSelecting = false;
        }
        
    }

    public void HpUp()
    {
        playerhpveiw.maxValue += 15;
        MaxHp += 15;
        Hp += 15;
        playerhpveiw.value = Hp;
    }
    
    public void FullHp()
    {
        Hp = MaxHp;
        playerhpveiw.value = Hp;
    }
    public void HpDecrease()
    {
        if (Hp > 0)
        {
            if (_hpDecrease is null)
            {
                _hpDecrease = ChangeHealth(Hp);
                StartCoroutine(_hpDecrease);
            }
            else
            {
                StopCoroutine(_hpDecrease);
                _hpDecrease = ChangeHealth(Hp);
                StartCoroutine(_hpDecrease);
            }


        }
        else
        {
/*#if UNITY_EDITOR || UNITY_EDITOR_64 || UNITY_EDITOR_WIN
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif*/
            SceneManager.LoadScene("TitleScene");
            
        
        }
    }

    private IEnumerator ChangeHealth(float health)
    {
        StartCoroutine(InfiniteTime());
        for (float i = 0; i < 0.2f; i += Time.deltaTime)
        {
            playerhpveiw.value = Mathf.Lerp(playerhpveiw.value, health, 2 * Time.deltaTime);
            yield return null;
        }
        playerhpveiw.value = health;
        yield return new WaitForSeconds(infinatetime);
    }

    public void SetExp()
    {
        playerexpveiw.value = Exp;
    }

    public void SetHp()
    {
        playerhpveiw.value = Hp;
    }
    
    private IEnumerator InfiniteTime()
    {
        isinfinate = true;
        yield return new WaitForSeconds(1f);
        isinfinate = false;
        

    }
    
    
}