using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
namespace rpgStealth 
{
    public class PostProcessingManager : MonoBehaviour
    {
        [SerializeField] private Volume portProcessingVolume;
         private DepthOfField depthOfField;
        private void OnEnable()
        {
            EventManager.StartListening("OnEnableMainMenu", OnActivateBlur);
            EventManager.StartListening("OnDisableMainMenu", OnDisableBlur);
        }

        private void OnDisable()
        {
            EventManager.StopListening("OnEnableMainMenu", OnActivateBlur);
            EventManager.StopListening("OnDisableMainMenu", OnDisableBlur);
        }

        private void Start()
        {
            portProcessingVolume.profile.TryGet(out depthOfField);
        }

        private void OnActivateBlur(Dictionary<string, object> message)
        {
            depthOfField.active = true;
        }

        private void OnDisableBlur(Dictionary<string, object> message)
        {
            depthOfField.active = false;
        }
    }
}
