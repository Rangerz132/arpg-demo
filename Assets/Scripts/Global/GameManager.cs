using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace rpgStealth
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one GameManager instance");
            }
            else
            {
                Instance = this;
            }
        }
    }
}
