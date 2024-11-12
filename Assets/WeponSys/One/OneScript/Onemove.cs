using Player.playerscript;
using UnityEngine;

namespace WeponSys.One.OneScript
{
    public class OneMove : MonoBehaviour
    {
        private GameObject _player;
        private PlayerMove _playerMove;
        public static float spinspeed;
        void Start()
        {
            spinspeed = 200f;
            _player = GameObject.FindWithTag("player");
            _playerMove = _player.GetComponent<PlayerMove>();
        }
        
        void Update()
        {
            transform.position=_player.transform.position;
            transform.Rotate(new Vector3(0,0,spinspeed*Time.deltaTime));
        }
    }
}
