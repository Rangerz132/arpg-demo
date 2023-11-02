using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public abstract class MainMenuTab : MonoBehaviour
    {      
        [field: SerializeField] public string key { get; private set; }
    }
}
