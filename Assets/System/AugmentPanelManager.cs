using UnityEngine;

namespace System
{
    public class AugmentPanelManager : MonoBehaviour
    {
        public static Action selectionTime;
        public AugmentsUi[] augmentsUis;
        public AugmentName[] augmentNames;
        public AugmentImage[] augmentImages;
        public AugmentsDescription[] augmentsDescriptions;

        void Start()
        {
            selectionTime = SelectionTime;
            gameObject.SetActive(false);
        }
        public void SelectionTime()
        {
            foreach (var t in augmentsUis)
            {
                t.RandomAugment();
            }

            foreach (var t in augmentNames)
            {
                t.SetAugmentName();
            }

            foreach (var t in augmentImages)
            {
                t.SetAugmentImage();
            }

            foreach (var t in augmentsDescriptions)
            {
                t.SetAugmentDescription();
            }
        }
    }
}
