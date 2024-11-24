using System.Collections;
using System.Collections.Generic;
using system;
using UnityEngine;

public class FrogChild : MonoBehaviour
{
    public Dialog[] dialogs;
    public DialogNode diaSlot;
    public void RandomText()
    {
        var idx = Random.Range(0, dialogs.Length);
        diaSlot.dialogs[0] = dialogs[idx];
    }
}
