using System;
using OtherObj;
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
        public InteractingWith isInteractingWith;
        private bool isActived;
        private GameObject gatcha;
        private Collider2D _other;
        private void Awake()
        {
            gatcha = GameObject.FindWithTag("gatcha");
        }

        // Start is called before the first frame update
        void Start()
        {
            isActived = false;
            isInteractingWith = InteractingWith.None;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (isInteractingWith)
                {
                    case InteractingWith.LootChest when !isActived:
                        gatcha.SetActive(true);
                        ItemPanelManager.selectionTime.Invoke();
                        break;
                    case InteractingWith.Door:
                        _other.gameObject.GetComponent<Door>().OpenTheDoor();
                        break;
                }
            }
            isActived = gatcha.activeSelf;
        }

        private void OnTriggerEnter2D(Collider2D other)
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
        }

        private void OnTriggerExit2D(Collider2D playercolider)
        {
            if (playercolider.gameObject.CompareTag("lootchest"))
            {
                isInteractingWith = InteractingWith.None;
            }
            else if (playercolider.gameObject.CompareTag("door"))
            {
                isInteractingWith = InteractingWith.None;
            }
        }
    }
}