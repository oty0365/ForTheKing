using System;
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
            if (!isActived && isInteractingWith == InteractingWith.LootChest && Input.GetKeyDown(KeyCode.F))
            {
                gatcha.SetActive(true);
                ItemPanelManager.selectionTime.Invoke();

            }
            isActived = gatcha.activeSelf;
        }

        private void OnTriggerEnter2D(Collider2D playercolider)
        {
            if (playercolider.gameObject.CompareTag("lootchest"))
            {
                Interaction.interactedBox = playercolider.gameObject;
                isInteractingWith = InteractingWith.LootChest;
            }
        }

        private void OnTriggerExit2D(Collider2D playercolider)
        {
            if (playercolider.gameObject.CompareTag("lootchest"))
            {
                isInteractingWith = InteractingWith.None;
            }
        }
    }
}