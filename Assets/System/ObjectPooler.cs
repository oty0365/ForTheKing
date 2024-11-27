using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace System
{
    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler instance;
        public Dictionary<string, Queue<GameObject>> objectPoolList;

        private void Awake()
        {
            instance = this;
            instance.objectPoolList = new Dictionary<string, Queue<GameObject>>();
        }

        public void ReBakeObjectPooler()
        {
            objectPoolList = new Dictionary<string,Queue<GameObject>>();
        }
        
        public void Get(GameObject t,Vector2 position,Quaternion quaternion)
        {
            if (!objectPoolList.ContainsKey(t.name))
            {
                objectPoolList.Add(t.name,new Queue<GameObject>());
                
            }
            if (objectPoolList[t.name].Count == 0)
            {
                Instantiate(t, position, quaternion);
                
            }
            else
            {
                var obj = objectPoolList[t.name].Dequeue();
                obj.transform.position = position;
                obj.transform.rotation = quaternion;
                obj.SetActive(true);
            }
        }

        public void Return(GameObject t)
        {
            if (!instance.objectPoolList.ContainsKey(t.name.Replace("(Clone)","")))
            { 
                instance.objectPoolList.Add(t.name,new Queue<GameObject>());
            }
            t.SetActive(false);
            objectPoolList[t.name.Replace("(Clone)","")].Enqueue(t);
            
        }
    }
}
