using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Player.playerscript
{
    public class PlayerMove : MonoBehaviour
    {
        public float movespeed;
        private bool iswalking;
        [SerializeField] private Animator playerani;
        private Vector3 playerdir;
        private Vector3 playerdestination;
        public static bool isdashing;
        private Rigidbody2D rb;
        public float dashamount;
        private bool dashingonwall;
        private Vector2 dir;
        private Vector2 dashDir = new Vector3(1, 0, 0);
        [SerializeField]private float dashcooldown;
        private SpriteRenderer sr;
        private bool candash;
        [SerializeField] private LayerMask enemy;

        [SerializeField] private Collider2D hitbox;
        // Start is called before the first frame update
        void Start()
        {
            sr = gameObject.GetComponent<SpriteRenderer>();
            rb = gameObject.GetComponent<Rigidbody2D>();
            isdashing = false;
            iswalking = false;
            playerani.SetBool("isidle", true);
            playerani.SetBool("isrun", false);
            dashingonwall = false;
            candash = true;
        }

        // Update is called once per frame
        void Update()
        {
            PlayerBasicMovement();
            PlayerAnimation();
            PlayerDash();
        }

        private void PlayerBasicMovement()
        {
            iswalking = false;
            dir = Vector2.zero;
            if (Input.GetKey(KeyCode.W)&&!isdashing)
            {
                iswalking = true;
                dir.y += 1;
            }

            if (Input.GetKey(KeyCode.S)&&!isdashing)
            {
                iswalking = true;
                dir.y -= 1;
            }

            if (Input.GetKey(KeyCode.A)&&!isdashing)
            {
                iswalking = true;
                transform.localScale = new Vector3(-1.2f, 1.2f, 0);
                dir.x -= 1;
            }

            if (Input.GetKey(KeyCode.D)&&!isdashing)
            {
                iswalking = true;
                transform.localScale = new Vector3(1.2f, 1.2f, 0);
                dir.x += 1;
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                iswalking = false;
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                iswalking = false;
            }
            if (dir == Vector2.zero) return;
            dir = dir.normalized;
            rb.position += movespeed * Time.deltaTime * dir;
            dashDir = dir;
        }

        private void PlayerAnimation()
        {
            switch (iswalking)
            {
                case false:
                    playerani.SetBool("isidle", true);
                    playerani.SetBool("isrun", false);
                    break;
                case true:
                    playerani.SetBool("isidle", false);
                    playerani.SetBool("isrun", true);
                    iswalking = false;
                    break;
            }
        }

        private void PlayerDash()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isdashing && candash && PlayerInteraction.instance.isInteractingWith != InteractingWith.Npc)
            {
                    isdashing = true;
                    candash = false;
                    StartCoroutine(Dash());
                    
            }

        }

        private IEnumerator Dash()
        {
            sr.color=Color.black;
            hitbox.excludeLayers += enemy;
            for (float i = 0; i <0.5 ; i+=Time.deltaTime)
            {
                if(!dashingonwall)
                {
                    var dashRange = Time.deltaTime * dashamount * 3.6f;
                    rb.MovePosition(rb.position+= dashDir * dashRange);

                }
                yield return null;
            }
            hitbox.excludeLayers -= enemy;
            sr.color=Color.white;
            isdashing = false;

            yield return new WaitForSeconds(dashcooldown);
            candash = true;
        }

        void OnCollisionEnter2D(Collision2D collider2D)
        {
            if (collider2D.gameObject.CompareTag("wall"))
            {
                dashingonwall = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collider2D)
        {
            if (collider2D.gameObject.CompareTag("wall"))
            {
                dashingonwall = false;
            }
        }
    }
}