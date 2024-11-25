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
        private float _horizontal;
        private float _vertical;
        [SerializeField] private LayerMask enemy;

        [SerializeField] private Collider2D hitbox;
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
        void Update()
        {
            MovementInput();
            PlayerBasicMovement();
            PlayerFlip();
            PlayerAnimation();
            PlayerDash();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(_horizontal, _vertical).normalized * movespeed;
        }

        private void MovementInput()
        {
            if (isdashing) return;
            _horizontal=Input.GetAxisRaw("Horizontal");
            _vertical=Input.GetAxisRaw("Vertical");

        }
        private void PlayerBasicMovement()
        {
            if (rb.velocity == Vector2.zero)
            {
                iswalking = false;
            }
            else
            {
                iswalking = true;
            }
        }

        private void PlayerFlip()
        {
            if (!iswalking) return;
            if ((int)_horizontal == 1)
            {
                transform.localScale = new Vector3(1.2f, 1.2f, 0);
            }
            else if ((int)_horizontal == -1)
            {
                transform.localScale = new Vector3(-1.2f, 1.2f, 0);
            }
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
            isdashing = true;
            sr.color=Color.black;
            hitbox.excludeLayers += enemy;
            var xdir =0f;
            var ydir = _vertical;
            if (iswalking)
            {
                xdir = _horizontal;
            }
            else
            {
                xdir = transform.localScale.x > 0 ? 1 : -1;
            }
            dashDir = new Vector2(xdir, ydir);
            dashDir = dashDir.normalized;
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