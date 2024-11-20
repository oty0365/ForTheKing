using System;
using UnityEngine;

namespace OtherObj
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private GameObject doorChild;
        [SerializeField] private GameObject doorGrandChild;
        [SerializeField] private float speed;
        private float _dCAngle;
        private float _dGCAngle;
        private Animator _ani;
        private CircleCollider2D _cc2D;
        private void Start()
        {
            _dCAngle = doorChild.transform.position.z;
            _dGCAngle = doorGrandChild.transform.position.z;
            _ani = transform.parent.GetComponent<Animator>();
            _cc2D = GetComponent<CircleCollider2D>();
        }

        private void Update()
        {
            _dCAngle += speed * Time.deltaTime;
            _dGCAngle += speed * Time.deltaTime * -2;
            doorChild.transform.rotation = Quaternion.Euler(0,0,_dCAngle);
            doorGrandChild.transform.rotation = Quaternion.Euler(0,0,_dGCAngle);
        }

        public void OpenTheDoor()
        {
            _cc2D.enabled = false;
            _ani.SetBool("open",true);
        }
        
    }
}
