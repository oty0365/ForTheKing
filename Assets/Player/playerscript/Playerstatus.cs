using System.Collections;
using System.Pause;
using Enemies;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public static float Hp;
    public static float Gold;
    public static float Exp;
    public static float MaxExp=50;
    public static float AttakDmg = 0;
    [SerializeField] private Slider playerhpveiw;
    [SerializeField] private Slider playerexpveiw;
    [SerializeField] private GameObject augmentSelect;
    [SerializeField] private WeaponArray weaponArray;
    public float damageamount;
    public bool isinfinate;
    public int gotdamge;
    public float infinatetime;
    private bool _isActive;
    void Start()
    {
        Hp = 100f;
        Exp = 0f;
        Gold = 0;
        _isActive = false;
        playerhpveiw.value = Hp;
        playerexpveiw.maxValue = MaxExp;
        playerexpveiw.value = Exp;
        isinfinate = false;
        gotdamge = 0;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        if (gotdamge!=0 && !isinfinate)
        {
            HpDecrease();
        }
        

    }

    private void ExpCheck()
    {
        
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

    public void ExpUp()
    {
        playerexpveiw.value += Exp;
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