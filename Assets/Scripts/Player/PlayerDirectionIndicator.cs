using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class PlayerDirectionIndicator : MonoBehaviour
    {
        private Quaternion currentQuaternionRotation;

        void Update()
        {
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
            Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float angle = Mathf.Atan2(positionOnScreen.y - mouseOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0f, -angle + 90, 0f));
            currentQuaternionRotation = Quaternion.Euler(new Vector3(0f, -angle - 90, 0f));
        }

        public Quaternion getCurrentQuaternionRotation()
        {
            return this.currentQuaternionRotation;
        }
    }
}
