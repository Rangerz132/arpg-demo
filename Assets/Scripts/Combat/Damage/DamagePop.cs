using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace rpgStealth
{
    public class DamagePop : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private TextMeshPro text;
        [SerializeField] private Vector3 positionOffset;
        [SerializeField] private float movementSpeed;

        private Action<DamagePop> OnDestroyObject;
        [SerializeField] private float lifeTime = 1;
        [SerializeField] private float initialLifeTime = 1;
        [SerializeField] private bool isSpawn;

        public void Initialize(Action<DamagePop> OnDestroyObject)
        {
            this.OnDestroyObject = OnDestroyObject;
        }

        public void Update()
        {
            if (isSpawn)
            {
                Move();
                HandleLifeTime();
            }
        }

        /// <summary>
        /// Set Inactive after a certain amount of time
        /// </summary>
        public void HandleLifeTime()
        {
            lifeTime -= Time.deltaTime;

            if (lifeTime <= 0)
            {
                OnDestroyObject?.Invoke(this);
                isSpawn = false;
            }
        }

        /// <summary>
        /// Move gameObject in the Y axe
        /// </summary>
        private void Move()
        {
            transform.position += new Vector3(0, movementSpeed * Time.deltaTime, 0);
        }

        /// <summary>
        /// Reset data when the object is spawned
        /// </summary>
        public void Reset()
        {
            isSpawn = true;
            lifeTime = initialLifeTime;
        }

        /// <summary>
        /// Set text value and its position
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="position"></param>
        public void SetProperties(int damage, Vector3 position)
        {
            animator.Play("DamagePop");
            text.text = damage.ToString();
            transform.position = position + positionOffset;
        }
    }
}
