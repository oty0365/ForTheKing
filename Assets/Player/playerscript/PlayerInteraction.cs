using System;
using OtherObj;
using system;
using UnityEngine;

namespace Player.playerscript
{
    public enum InteractingWith
    {
        None,
        LootChest,
        Npc,
        Door,
        Other
    }
    public class PlayerInteraction : MonoBehaviour
    {
        public static PlayerInteraction instance;
        public InteractingWith isInteractingWith;
        private bool isActived;
        private bool isTalking;
        private GameObject gatcha;
        public Vector2 rayCastDir;
        [SerializeField] private GameObject talking;
        private Collider2D _other;
        public LayerMask interactLayer;
        private void Awake()
        {
            instance = this;
            gatcha = GameObject.FindWithTag("gatcha");
        }

        // Start is called before the first frame update
        void Start()
        {
            isActived = false;
            isTalking = false;
            isInteractingWith = InteractingWith.None;
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit2D hit;
            if (PlayerMove.instance.dir != Vector2.zero)
            {
                rayCastDir = new Vector2(PlayerMove.instance.dir.x, PlayerMove.instance.dir.y);
            }
            _other=Physics2D.OverlapCircle(gameObject.transform.position, 2f,interactLayer);
            
                switch (_other?.tag)
                {
                    case "lootchest":
                        isInteractingWith = InteractingWith.LootChest;
                        break;
                    case "door":
                        isInteractingWith = InteractingWith.Door;
                        break;
                    case "npc":
                        isInteractingWith = InteractingWith.Npc;
                        break;
                    default:
                        isInteractingWith = InteractingWith.None;
                        break;
                }
            
                
            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (isInteractingWith)
                {
                    case InteractingWith.LootChest when !isActived:
                        gatcha.SetActive(true);
                        ItemPanelManager.selectionTime.Invoke();
                        Destroy(_other.gameObject);
                        break;
                    case InteractingWith.Door:
                        _other.gameObject.GetComponent<Door>().OpenTheDoor();
                        break;
                    case InteractingWith.Npc when !isTalking:
                        _other.gameObject.GetComponent<Conversation>().Talk();
                        break;
                }
            }

            isTalking = talking.activeSelf;
            isActived = gatcha.activeSelf;
        }

        /*private void OnTriggerEnter2D(Collider2D other)
        {
            _other = other;
            if (other.gameObject.CompareTag("lootchest"))
            {
                Interaction.interactedBox = other.gameObject;
                isInteractingWith = InteractingWith.LootChest;
            }

            else if (other.CompareTag("door"))
            {
                Interaction.interactedBox = other.gameObject;
                isInteractingWith = InteractingWith.Door;
            }
            else if (other.CompareTag("npc"))
            {
                Interaction.interactedBox = other.gameObject;
                isInteractingWith = InteractingWith.Npc;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("lootchest"))
            {
                isInteractingWith = InteractingWith.None;
            }
            else if (other.gameObject.CompareTag("door"))
            {
                isInteractingWith = InteractingWith.None;
            }
            else if (other.CompareTag("npc"))
            {
                isInteractingWith = InteractingWith.None;
            }
        }*/
    }
}