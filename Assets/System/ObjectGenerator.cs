using UnityEngine;
using Screen = UnityEngine.Device.Screen;

namespace System
{
    public class ObjectGenerator : Generator
    {
        private void Start()
        {
            
            generatePos = new Vector2(0, 0);
            Spawn(preFab);
        }
    }
}
