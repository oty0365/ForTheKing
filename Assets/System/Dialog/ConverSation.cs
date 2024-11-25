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
    public DialogLocation curLocation;
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
    public int curindx;
    private DialogNode _originHead;
    [Header("말을 반복하는지에대한 여부")]
    public bool repeat;
    public Action startTalk;
    private void Start()
    {
      curLocation = new DialogLocation();
      startTalk = Talk;
      _value = 1f;
      _conversationModal = DialogManger.instance.conversation;
      _dialogModal = DialogManger.instance.dialogModel;
      _selectionModal = DialogManger.instance.selectionModel;
      _characterName = DialogManger.instance.characterName;
      _faceImg = DialogManger.instance.faceImg;
      _characterDialog = DialogManger.instance.characterDialog;
      _selection1 = DialogManger.instance.selection1;
      _selection2 = DialogManger.instance.selection2;
      _timeout = DialogManger.instance.timeout;
      _buttonText1 = DialogManger.instance.buttonText1;
      _buttonText2 = DialogManger.instance.buttonText2;
      _conversationModal.SetActive(false);
      _originHead = header;
      curindx = 0;
    }

    public void Talk()
    {
      _conversationModal.SetActive(true);
      _selectionModal.SetActive(false);
      _dialogModal.SetActive(true);
      
      if (ConversationList.Dialogs.ContainsKey(talker))
      {
        curLocation = ConversationList.Dialogs[talker];
        curindx = curLocation.idx;
        header = curLocation.dialogNode;
      }
      else
      {
        ConversationList.Dialogs.Add(talker, curLocation);
      }

      if (repeat)
      {
        header = _originHead;
      }
      StartCoroutine(TalkFlow());

    }

    private IEnumerator TalkFlow()
    {
      PutText();
      while (true)
      {
        if (Input.GetKeyDown(KeyCode.Space) && header.dialogs[curindx].canSelect && !_selectionModal.activeSelf)
        {
          _selectionModal.SetActive(true);
          StartCoroutine(SelectionFlow());
          yield break;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !header.dialogs[curindx].canSelect)
        {
          header.dialogs[curindx].comingEvent.Invoke();
            if (curindx < header.dialogs.Length-1)
            {
              curindx++;
              PutText();
            }
            else
            {
              _conversationModal.SetActive(false);
              if (repeat)
              {
                ConversationList.Dialogs[talker] = curLocation;
              }
              else
              {
                curLocation.dialogNode = header;
                curLocation.idx = curindx-1;
                ConversationList.Dialogs[talker] = curLocation;
              }
              
              yield break;
            }
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
      if (header.dialogs[curindx].isSelectingRight)
      {
        _selection1.image.color = Color.white;
        _selection2.image.color = Color.green;
      }
      else
      {
        _selection1.image.color = Color.green;
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
            header = header.dialogs[curindx].respond1;
            _selectionModal.SetActive(false);
            curindx = 0;
            StartCoroutine(TalkFlow());
            _selection1.onClick.RemoveListener(Respond1);
            _selection2.onClick.RemoveListener(Respond2);
            yield break;
          case 2:
            header = header.dialogs[curindx].respond2;
            _selectionModal.SetActive(false);
            curindx = 0;
            StartCoroutine(TalkFlow());
            _selection1.onClick.RemoveListener(Respond1);
            _selection2.onClick.RemoveListener(Respond2);
            yield break;
        }
        yield return null;
      }
      
      _selectionModal.SetActive(false);
      //header = header.dialogs[header.dialogs.isSelectingRight ? 1 : 0];
      StartCoroutine(TalkFlow());
    }

    public void PutText()
    {
      _faceImg.sprite = header.dialogs[curindx].faceImg;
      _characterName.text = header.dialogs[curindx].characterName;
      _characterDialog.text = header.dialogs[curindx].diaText;
    }
    
    private void PutSelect()
    {
      _buttonText1.text = header.dialogs[curindx].selection1;
      _buttonText2.text = header.dialogs[curindx].selection2;
    }

    public void Respond1()
    {
      _respond = 1;
      header.dialogs[curindx].comingEvent.Invoke();
    }

    public void Respond2()
    {
      _respond = 2;
    }
  }
}
