using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

namespace rpgStealth
{
    public class CameraShake : MonoBehaviour
    {
        private CinemachineImpulseSource cinemachineImpulseSource;

        private void OnEnable()
        {
            EventManager.StartListening("OnEnemyHit", OnEnemyHit);
        }

        private void OnDisable()
        {
            EventManager.StopListening("OnEnemyHit", OnEnemyHit);
        }

        // Start is called before the first frame update
        private void Start()
        {
            cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        }

        private void OnEnemyHit(Dictionary<string, object> message)
        {
            Vector3 cameraImpulseVelocity = (Vector3)message["cameraImpusleVelocity"];
            cinemachineImpulseSource.GenerateImpulseWithVelocity(cameraImpulseVelocity);
        }
    }
}
