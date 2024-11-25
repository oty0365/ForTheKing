using System;
using System.Collections;
using System.Collections.Generic;
using system;
using UnityEngine;
using Random = UnityEngine.Random;

public class FrogChild : MonoBehaviour
{
    public DialogNode diaSlot;
    [SerializeField]private Conversation frogChild;
    [TextArea] public string[] talks;
    
    public void RandomText()
    {
        frogChild.curindx = 0;
        var idx = Random.Range(0, talks.Length);
        diaSlot.dialogs[frogChild.curindx].diaText = talks[idx];
    }
}
