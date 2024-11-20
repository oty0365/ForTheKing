using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace system
{
  public class Conversation : MonoBehaviour
  {
    [Header("대화의 주체")] 
    public string talker;
    [Header("대화")]
    public DialogNode header;

    private GameObject _conversationModal;
    private GameObject _dialogModal;
    private GameObject _selectionModal;
    private TextMeshProUGUI _characterName;
    private TextMeshProUGUI _characterDialog;
    private Image _faceImg;
    private Button _selection1;
    private Button _selection2;
    private TextMeshProUGUI _buttonText1;
    private TextMeshProUGUI _buttonText2;
    private Slider _timeout;
    private float _value;
    private int _respond;
    public Action startTalk;
    private void Start()
    {
      startTalk = Talk;
      _value = 1f;
      _conversationModal = GameObject.FindWithTag("conversation").gameObject;
      _dialogModal = _conversationModal.transform.GetChild(0).gameObject;
      _selectionModal = _conversationModal.transform.GetChild(1).gameObject;
      _characterName = _dialogModal.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
      _faceImg = _dialogModal.transform.GetChild(2).gameObject.GetComponent<Image>();
      _characterName = _dialogModal.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
      _characterDialog = _dialogModal.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
      _selection1 = _selectionModal.transform.GetChild(3).gameObject.GetComponent<Button>();
      _selection2 = _selectionModal.transform.GetChild(2).gameObject.GetComponent<Button>();
      _timeout = _selectionModal.transform.GetChild(0).gameObject.GetComponent<Slider>();
      _buttonText1 = _selection1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
      _buttonText2 = _selection2.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
      _conversationModal.SetActive(false);
      Talk();
    }

    public void Talk()
    {
      _conversationModal.SetActive(true);
      _selectionModal.SetActive(false);
      _dialogModal.SetActive(true);
      
      if (ConversationList.Dialogs.ContainsKey(talker))
      {
        header = ConversationList.Dialogs[talker];
      }
      else
      {
        ConversationList.Dialogs.Add(talker, header);
      }

      StartCoroutine(TalkFlow());

    }

    private IEnumerator TalkFlow()
    {
      PutText();
      while (header.child is not null)
      {
        if (Input.GetKeyDown(KeyCode.Space)&&!header.dialogs.canSelect)
        {
          try
          {
            header = header.child[0];
          }
          catch
          {
            _conversationModal.SetActive(false);
          }

          PutText();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && header.dialogs.canSelect && !_selectionModal.activeSelf)
        {
          _selectionModal.SetActive(true);
          StartCoroutine(SelectionFlow());
        }
        yield return null;
      }
    }

    private IEnumerator SelectionFlow()
    {
      _respond = 0;
      PutSelect();
      _value = 1f;
      _selectionModal.SetActive(true);
      if (header.dialogs.isSelectingRight)
      {
        _selection1.image.color = Color.white;
        _selection2.image.color = Color.red;
      }
      else
      {
        _selection1.image.color = Color.red;
        _selection2.image.color = Color.white;
      }
      _selection1.onClick.AddListener(Respond1);
      _selection2.onClick.AddListener(Respond2);
      while(_value>0)
      {
        _timeout.value = _value;
        _value -= Time.deltaTime * 0.25f;
        switch (_respond)
        {
          case 1:
            header = header.child[0];
            _selectionModal.SetActive(false);
            StartCoroutine(TalkFlow());
            _selection1.onClick.RemoveListener(Respond1);
            _selection2.onClick.RemoveListener(Respond2);
            yield break;
          case 2:
            header = header.child[1];
            _selectionModal.SetActive(false);
            StartCoroutine(TalkFlow());
            _selection1.onClick.RemoveListener(Respond1);
            _selection2.onClick.RemoveListener(Respond2);
            yield break;
        }
        yield return null;
      }
      
      _selectionModal.SetActive(false);
      header = header.child[header.dialogs.isSelectingRight ? 1 : 0];
      StartCoroutine(TalkFlow());
    }

    private void PutText()
    {
      _faceImg.sprite = header.dialogs.faceImg;
      _characterName.text = header.dialogs.characterName;
      _characterDialog.text = header.dialogs.diaText;
    }

    private void PutSelect()
    {
      _buttonText1.text = header.dialogs.selection1;
      _buttonText2.text = header.dialogs.selection2;
    }

    public void Respond1()
    {
      _respond = 1;
    }

    public void Respond2()
    {
      _respond = 2;
    }
  }
}
