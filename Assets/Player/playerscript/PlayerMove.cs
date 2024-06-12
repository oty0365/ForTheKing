using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movespeed;
    private bool iswalking;
    [SerializeField] private Animator playerani;
    // Start is called before the first frame update
    void Start()
    {
        iswalking = false;
        playerani.SetBool("isidle",true);
        playerani.SetBool("isrun",false);
    }

    // Update is called once per frame
    void Update()
    {
        playerbasicmovement();
        playeranimation();
    }

    void playerbasicmovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            iswalking = true;
            transform.position += new Vector3(0, movespeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            iswalking = true;
            transform.position -= new Vector3(0, movespeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            iswalking = true;
            transform.position -= new Vector3(movespeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1.2f, 1.2f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            iswalking = true;
            transform.position += new Vector3(movespeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1.2f, 1.2f, 0);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            iswalking = false;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            iswalking = false;
        }
    }

    void playeranimation()
    {
        
        if (!iswalking)
        {
            playerani.SetBool("isidle",true);
            playerani.SetBool("isrun",false);
        }
        else if (iswalking)
        {
            playerani.SetBool("isidle",false);
            playerani.SetBool("isrun",true);
            iswalking = false;
        }
    }
}
