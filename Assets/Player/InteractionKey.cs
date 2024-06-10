using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionKey : MonoBehaviour
{
    [SerializeField] private GameObject playerData;
    private PlayerInteraction _playerData;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = playerData.GetComponent<PlayerInteraction>();
        Natural();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(playerData.transform.position.x, playerData.transform.position.y + 1f);
        if (_playerData.isinteractingwithbox)
        {
            Triggered();
        }
        else
        {
            Natural();
        }
    }
    private void Natural()
    {
        Vector3 curentScale = gameObject.transform.localScale;
        curentScale.x = 0f;
        curentScale.y = 0f;
        gameObject.transform.localScale = curentScale;
    }

    private void Triggered()
    {
        Vector3 curentScale = gameObject.transform.localScale;
        curentScale.x = 0.4f;
        curentScale.y = 0.4f;
        gameObject.transform.localScale = curentScale;
    }
}
