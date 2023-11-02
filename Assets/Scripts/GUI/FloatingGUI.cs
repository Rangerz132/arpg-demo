using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class FloatingGUI : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
