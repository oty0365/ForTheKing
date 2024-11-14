using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace System
{
    public class ObjectPoolQueue
    {
        public Queue<GameObject> objectPoolQueue;
    }
    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler instance;
        public Dictionary<string,ObjectPoolQueue> objectPoolList;
        public int currentidx;

        private void Awake()
        {
            instance = this;
            currentidx = 0;
        }

        public void ReBkeObjectPooler()
        {
            objectPoolList = new Dictionary<string, ObjectPoolQueue>();
        }

        public void Get(string curidx, GameObject t,Vector2 position,Quaternion quaternion)
        {
            if (!objectPoolList.ContainsKey(curidx))
            {
                objectPoolList.Add(curidx,new ObjectPoolQueue());
            }
            else
            {
                if (objectPoolList[curidx].objectPoolQueue.Count == 0)
                {
                    Instantiate(t, position, quaternion);
                }
                else
                {
                    var obj = objectPoolList[curidx].objectPoolQueue.Dequeue();
                    obj.SetActive(true);
                }
            }
        }

        public void Return(string curidx, GameObject t)
        {
            if (!objectPoolList.ContainsKey(curidx))
            {
                objectPoolList.Add(curidx,new ObjectPoolQueue());
            }
            else
            {
                t.SetActive(false);
                objectPoolList[curidx].objectPoolQueue.Enqueue(t);
            }
        }
        private void Start()
        {
            
        }
        
        private void Update()
        {
        
        }
    }
}
