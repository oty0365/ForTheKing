using UnityEngine;

namespace LootChest.Chapter1.WoodenChest
{
    public class RandomSpawn : MonoBehaviour
    {
        private float Xpos;
        private float Ypos;
        // Start is called before the first frame update
        void Start()
        {
            Xpos = Random.Range(-15,15);
            Ypos = Random.Range(-15,15);
            transform.position = new Vector3(Xpos,Ypos, 0);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
