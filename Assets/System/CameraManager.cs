using Cinemachine;
using UnityEngine;

namespace System
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager instance;
        private CinemachineBrain _cinemachine;
        public CinemachineVirtualCamera cinemachineVirtualCamera;
        private void Start()
        {
            instance = this;
        }
        public void ChangeCamera(GameObject target)
        {
            cinemachineVirtualCamera.Follow = target.transform;
            cinemachineVirtualCamera.LookAt = target.transform;
        }
    }
}
