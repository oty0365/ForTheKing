using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManger : MonoBehaviour
{
    public static DialogManger instance;
    public GameObject conversation;
    public GameObject dialogModel;
    public GameObject selectionModel;
    public TextMeshProUGUI characterName;
    public Image faceImg;
    public TextMeshProUGUI characterDialog;
    public Button selection1;
    public Button selection2;
    public Slider timeout;
    public TextMeshProUGUI buttonText1;
    public TextMeshProUGUI buttonText2;

    private void Awake()
    {
        instance = this;
    }
}
