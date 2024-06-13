using System.Collections;
using System.Collections.Generic;
using Player.playerscript;
using UnityEngine;

public class Onemove : MonoBehaviour
{
    public GameObject Player;
    private PlayerMove _player;
    public float spinspeed;
    // Start is called before the first frame update
    void Start()
    {
        _player = Player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=_player.transform.position;
        transform.Rotate(new Vector3(0,0,spinspeed*Time.deltaTime));
    }
}
