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

        private void Start()
        {
            _dCAngle = doorChild.transform.position.z;
            _dCAngle = doorGrandChild.transform.position.z;
        }

        private void Update()
        {

            _dCAngle += speed * Time.deltaTime;
            _dGCAngle += speed * Time.deltaTime * -2;
            doorChild.transform.rotation = Quaternion.Euler(0,0,_dCAngle);
            doorGrandChild.transform.rotation = Quaternion.Euler(0,0,_dGCAngle);
        }
    }
}
