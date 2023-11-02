using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace rpgStealth
{
    public class StatsHolder : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entityName;
        [SerializeField] public TextMeshProUGUI level;
        [field: SerializeField] public Image HealthBarGauge { get; private set; }

        /// <summary>
        /// Set entity properties
        /// </summary>
        /// <param name="level"></param>
        /// <param name="entityName"></param>
        public void SetStats(string entityName, string level)
        {
            this.level.text = level;
            this.entityName.text = entityName;
        }
    }
}
