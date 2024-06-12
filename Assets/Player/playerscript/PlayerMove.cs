using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movespeed;
    private bool iswalking;
    [SerializeField] private Animator playerani;
    private string playerdirection;
    private Vector2 playerdestination;
    private bool candash;

    public float dashamount;

    // Start is called before the first frame update
    void Start()
    {
        candash = true;
        iswalking = false;
        playerani.SetBool("isidle", true);
        playerani.SetBool("isrun", false);
        playerdirection = "right";
    }

    // Update is called once per frame
    void Update()
    {
        playerbasicmovement();
        playeranimation();
        playerdash();
    }

    void playerbasicmovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            iswalking = true;
            transform.position += new Vector3(0, movespeed * Time.deltaTime, 0);
            playerdirection = "up";
        }

        if (Input.GetKey(KeyCode.S))
        {
            iswalking = true;
            transform.position -= new Vector3(0, movespeed * Time.deltaTime, 0);
            playerdirection = "down";
        }

        if (Input.GetKey(KeyCode.A))
        {
            iswalking = true;
            transform.position -= new Vector3(movespeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1.2f, 1.2f, 0);
            playerdirection = "left";
        }

        if (Input.GetKey(KeyCode.D))
        {
            iswalking = true;
            transform.position += new Vector3(movespeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1.2f, 1.2f, 0);
            playerdirection = "right";
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            iswalking = false;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            iswalking = false;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            playerdirection = "up-left";
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            playerdirection = "up-right";
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            playerdirection = "down-left";
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            playerdirection = "down-right";
        }
    }

    void playeranimation()
    {
        if (!iswalking)
        {
            playerani.SetBool("isidle", true);
            playerani.SetBool("isrun", false);
        }
        else if (iswalking)
        {
            playerani.SetBool("isidle", false);
            playerani.SetBool("isrun", true);
            iswalking = false;
        }
    }

    void playerdash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && candash)
        {
            candash = false;
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        if (playerdirection == "up")
        {
            playerdestination.y = transform.position.y + dashamount;
        }
        else if (playerdirection == "down")
        {
            playerdestination.y = transform.position.y - dashamount;
        }
        else if (playerdirection == "left")
        {
            playerdestination.x = transform.position.x - dashamount;
        }
        else if (playerdirection == "right")
        {
            playerdestination.x = transform.position.x + dashamount;
        }
        else if (playerdirection == "up-left")
        {
            playerdestination.y = transform.position.y + dashamount;
            playerdestination.x = transform.position.x - dashamount;
        }
        else if (playerdirection == "up-right")
        {
            playerdestination.y = transform.position.y + dashamount;
            playerdestination.x = transform.position.x + dashamount;
        }
        else if (playerdirection == "down-left")
        {
            playerdestination.y = transform.position.y - dashamount;
            playerdestination.x = transform.position.x - dashamount;
        }
        else if (playerdirection == "down-right")
        {
            playerdestination.y = transform.position.y - dashamount;
            playerdestination.x = transform.position.x + dashamount;
        }

        float timer = 0;
        float richTime = 1;
        Vector2 startPos = transform.position;
        while (timer < richTime)
        {
            timer += Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, playerdestination,
              timer / richTime  );
            yield return null;
        }

        candash = true;
    }
}