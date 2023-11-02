using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class FieldOfView : MonoBehaviour
    {
        [Range(0, 360)]
        [SerializeField] private float angle;
        [SerializeField] private float radius;
        [SerializeField] private GameObject target;
        [SerializeField] private LayerMask targetMask;
        [SerializeField] private LayerMask obstructionMask;

        public bool CanSeeTarget { get; private set; }

        private void Start()
        {
            StartCoroutine(FOVRoutine());
        }

        private IEnumerator FOVRoutine()
        {
            float delay = 0.2f;
            WaitForSeconds wait = new WaitForSeconds(delay);

            while (true)
            {


                FieldOfViewCheck();
                yield return wait;
            }
        }

        private void FieldOfViewCheck()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, targetMask);

            if (colliders.Length > 0)
            {
                Transform targetTransform = colliders[0].transform;
                Vector3 directionToTarget = (targetTransform.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    {
                        CanSeeTarget = true;
                    }
                    else
                    {
                        CanSeeTarget = false;
                    }
                }
                else
                {
                    CanSeeTarget = false;
                }
            }
            else
            {
                CanSeeTarget = false;
            }
        }

        public void ResetData()
        {
            CanSeeTarget = false;
        }
    }
}

