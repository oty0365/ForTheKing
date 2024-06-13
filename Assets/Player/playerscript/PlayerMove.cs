using System.Collections;
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
        private bool candash;
        private Rigidbody2D rb;
        public float dashamount;

        private Vector2 dir;
        private Vector2 dashDir = new Vector3(1, 0, 0);

        // Start is called before the first frame update
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            candash = true;
            iswalking = false;
            playerani.SetBool("isidle", true);
            playerani.SetBool("isrun", false);
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
            if (Input.GetKey(KeyCode.W))
            {
                iswalking = true;
                dir.y += 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                iswalking = true;
                dir.y -= 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                iswalking = true;
                transform.localScale = new Vector3(-1.2f, 1.2f, 0);
                dir.x -= 1;
            }

            if (Input.GetKey(KeyCode.D))
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
            if (!Input.GetKeyDown(KeyCode.Space) || !candash) return;
            candash = false;
            StartCoroutine(Dash());
        }

        private IEnumerator Dash()
        {
            for (var i = 0; i < 60; i++)
            {
                var dashRange = (Time.deltaTime * dashamount * 3.6f);
                rb.position += dashDir * dashRange;
                yield return null;
            }

            candash = true;
        }
    
    }
}