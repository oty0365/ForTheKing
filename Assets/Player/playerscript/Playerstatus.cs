using System;
using System.Collections;
using System.Pause;
using Enemies;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public static float Hp;
    public static float MaxHp=100;
    public static float Gold;
    public static float Exp;
    public static float MaxExp=50;
    public static float AttakDmg = 0;
    [SerializeField] private Slider playerhpveiw;
    [SerializeField] private Slider playerexpveiw;
    public float damageamount;
    public bool isinfinate;
    public int gotdamge;
    public float infinatetime;
    private bool _isActive;
    private GameObject _augmentSelect;
    private bool _isSelecting;
    public static Action setExp;
    public static Action hpUp;
    public static Action fullHp;
    public static Action setHp;
    private void Awake()
    {
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
        if (gotdamge!=0 && !isinfinate)
        {
            HpDecrease();
        }
        ExpCheck();
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

    private IEnumerator ChangeHealth(float health)
    {
        isinfinate = true;
        for (float i = 0; i < 0.2f; i += Time.deltaTime)
        {
            playerhpveiw.value = Mathf.Lerp(playerhpveiw.value, health, 2 * Time.deltaTime);
            yield return null;
        }
        playerhpveiw.value = health;
        yield return new WaitForSeconds(infinatetime);
        isinfinate = false;
    }

    public void SetExp()
    {
        playerexpveiw.value = Exp;
    }

    public void SetHp()
    {
        playerhpveiw.value = Hp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("enemyhitbox")) return;
        damageamount = other.transform.parent.GetComponent<EnemyAi>().damage;
        gotdamge++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("enemyhitbox"))
        {
            gotdamge--;
        }
    }
    
    
}