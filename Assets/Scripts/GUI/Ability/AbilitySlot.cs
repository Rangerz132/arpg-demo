using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace rpgStealth
{
    public class AbilitySlot : MonoBehaviour
    {
        [SerializeField] private Image overlay;
        [SerializeField] private Image abilityImage;
        [SerializeField] private float overlayOpacity;
        private string abilityName;
        private float cooldown;
        private float tick;
        private bool available;
        private float duration;

        void Update()
        {
            Cooldown();
        }

        /// <summary>
        /// Animate the cooldown effect
        /// </summary>
        private void Cooldown()
        {
            if (available)
            {
                return;
            }

            tick += Time.deltaTime / cooldown;
            overlay.fillAmount = Mathf.Lerp(1, 0, tick);

            if (overlay.fillAmount == 0)
            {
                ResetCooldown();
            }
        }

        /// <summary>
        /// Activate the cooldown effect
        /// </summary>
        public void TriggerCooldown()
        {
            available = false;
            Color color = overlay.color;
            color.a = overlayOpacity;
            overlay.color = color;
            tick = 0;
        }

        /// <summary>
        /// Reset cooldown elements
        /// </summary>
        private void ResetCooldown()
        {

            available = true;
            Color color = overlay.color;
            color.a = 0f;
            overlay.color = color;
            abilityImage.fillAmount = 1;
        }
        public void setImage(Sprite sprite)
        {
            abilityImage.sprite = sprite;
        }

        public void setName(string name)
        {
            abilityName = name;
        }

        public void setCooldown(float cooldown)
        {
            this.cooldown = cooldown;
        }

        public void setAvailable(bool available)
        {
            this.available = available;
        }

        public void setDuration(float duration)
        {
            this.duration = duration;
        }
    }
}
