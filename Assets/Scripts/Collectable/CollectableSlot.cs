using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace rpgStealth
{
    public class CollectableSlot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private Image itemIcon;
        [SerializeField] private float offsetMultiplicator;
        [SerializeField] private AnimationCurve animationCurve;
        [SerializeField] private RectTransform rectTransform;
        private float offsetY;
        public bool hasToMove;

        private float movementTimePosition;
        private Vector3 startPosition;
        private Vector3 targetPosition;

        private void Update()
        {
            if (hasToMove)
            {
                Move();
            }
        }

        public void SetInfo(ItemData_SO itemData)
        {
            itemName.text = itemData.itemName;
            itemIcon.sprite = itemData.icon;
        }

        public void SetMovementPosition()
        {
            offsetY = rectTransform.sizeDelta.y * offsetMultiplicator;
            startPosition = transform.localPosition;
            targetPosition = new Vector3(startPosition.x, startPosition.y + offsetY, startPosition.z);
        }

        public void Move()
        {
            movementTimePosition += Time.deltaTime;

            if (movementTimePosition < 1)
            {
                transform.localPosition = Vector3.Lerp(startPosition, targetPosition, animationCurve.Evaluate(movementTimePosition));
            }
            else
            {
                movementTimePosition = 0;
                startPosition = transform.localPosition;
                hasToMove = false;
            }
        }

        public void Reset()
        {
            transform.localPosition = Vector3.zero;
            startPosition = transform.localPosition;
            movementTimePosition = 0;
            hasToMove = false;
            gameObject.SetActive(false);
        }
    }
}
