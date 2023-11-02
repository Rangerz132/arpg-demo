using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace rpgStealth
{
    public class PauseManager : MonoBehaviour
    {
        public static PauseManager Instance { get; private set; }
        public bool isPaused;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one PauseManager instance");
            }
            else
            {
                Instance = this;
            }
        }

        /// <summary>
        /// Puase the game
        /// </summary>
        public void Pause() 
        {
            isPaused = true;
            Time.timeScale = 0;
        }

        /// <summary>
        /// Resume the game
        /// </summary>
        public void Resume()
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }

}
