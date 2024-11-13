using System.Pause;
using UnityEngine;

namespace System
{
    public class ItemPanelManager : MonoBehaviour
    {
        public static Action selectionTime;
        public WeaponArray[] weaponArrays;
        public ItemValue[] itemValue;
        public ItemDmgAmt[] itemDmgAmt;
        public ItemImage[] itemImages;
        public ItemText[] itemTexts;
        public ItemDescription[] itemDescriptions;
        public ItemRarity[] itemRarities;
        private void Start()
        {
            selectionTime = SelectionTime;
            gameObject.SetActive(false);
        }

        public void SelectionTime()
        {
            Gamepause.pauseGame.Invoke();
            foreach (var t in weaponArrays)
            {
                t.RandomWeapon();
            }
            foreach (var t in itemImages)
            {
                t.SetItemImage();
            }

            foreach (var t in itemTexts)
            {
                t.SetItemText();
            }
            foreach (var t in itemDescriptions)
            {
                t.SetItemDescriptions();
            }
            foreach (var t in itemDmgAmt)
            {
                t.SetItemDmgMnt();
            }
            foreach (var t in itemValue)
            {
                t.SetItemValue();
            }

            foreach (var t in itemRarities)
            {
                t.SetWeaponItemRarity();
            }
        }
        
    }
}
