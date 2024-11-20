using UnityEngine;

namespace System
{
    public class Generator : MonoBehaviour
    {
        protected Vector2 generatePos;
        [SerializeField]protected int startValue;
        [SerializeField]protected int spwanCount;
        [SerializeField] protected Camera spwanCamera;
        [SerializeField] protected Vector3 spwanAngle;
        protected int xPos;
        protected int yPos;
        public GameObject preFab;
        public void Spawn(GameObject preFabType)
        {
            for (; startValue <= spwanCount; startValue++)
            { 
                var orthographicSize = spwanCamera.orthographicSize; 
                xPos = UnityEngine.Random.Range((int)orthographicSize*-1,(int)orthographicSize);
                yPos = UnityEngine.Random.Range((int)orthographicSize*-1,(int)orthographicSize);
                generatePos = new Vector2(xPos, yPos);
                Debug.Log(preFabType);
                Check(preFabType);
               
            }
            GenerateList.generateList.Clear();
        }
        public void Check(GameObject preFabType)
        {
                if (GenerateList.generateList.Contains(generatePos))
                {
                    startValue--;
                }
                else
                {
                    GenerateList.generateList.Add(generatePos);
                    //Debug.Log(GenerateList.generateList);
                    var obj = Instantiate(preFabType, generatePos, Quaternion.Euler(spwanAngle));
                    obj.transform.parent = MapManagementSystem.instance.gameObject.transform.GetChild(0);
                }
                
        }
    }
}
