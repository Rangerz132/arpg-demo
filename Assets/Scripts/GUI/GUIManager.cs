using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class GUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameplayPanel;
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private List<MainMenuTab> mainMenuTabKeys;
        public Dictionary<string, MainMenuTab> mainMenuTabs = new Dictionary<string, MainMenuTab>();

        private void OnEnable()
        {
            EventManager.StartListening("OnEnableMainMenu", OnEnableMainMenu);
            EventManager.StartListening("OnDisableMainMenu", OnDisableMainMenu);          
        }

        private void OnDisable()
        {
            EventManager.StopListening("OnEnableMainMenu", OnEnableMainMenu);
            EventManager.StopListening("OnDisableMainMenu", OnDisableMainMenu);
        }

        private void Start()
        {
            InitializeMainMenuTabs();
        }

        /// <summary>
        /// Initialize the dictionnary to have access to all tabs
        /// </summary>
        private void InitializeMainMenuTabs()
        {
            for (var i = 0; i < mainMenuTabKeys.Count; i++)
            {
                mainMenuTabs.Add(mainMenuTabKeys[i].key, mainMenuTabKeys[i]);
            }
        }

        /// <summary>
        /// Enable the main menu and showcase the target tab
        /// </summary>
        /// <param name="message"></param>
        private void OnEnableMainMenu(Dictionary<string, object> message)
        {
            string key = (string)message["key"];

            mainMenuPanel.gameObject.SetActive(true);
            mainMenuTabs[key].gameObject.SetActive(true);
            gameplayPanel.gameObject.SetActive(false);
        }

        /// <summary>
        /// Disable main menu
        /// </summary>
        /// <param name="message"></param>
        private void OnDisableMainMenu(Dictionary<string, object> message)
        {
            mainMenuPanel.gameObject.SetActive(false);
            gameplayPanel.gameObject.SetActive(true);
        }
    }
}
