using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace rpgStealth
{
    public class AgentController : MonoBehaviour
    {
        public NavMeshAgent agent;
        [SerializeField] private GameObject target;
        public FieldOfView fieldOfView;
        public List<Vector3> destinationPoints = new List<Vector3>();
        private int destinationIndex = 0;

        /// <summary>
        /// Move to the next destination
        /// </summary>
        public void GoToNextDestination()
        {
            if (destinationIndex >= destinationPoints.Count)
            {
                destinationIndex = 0;
            }

            agent.SetDestination(destinationPoints[destinationIndex]);
            destinationIndex++;
        }

        /// <summary>
        /// Move to the target position
        /// </summary>
        public void GoToTarget()
        {
            agent.SetDestination(target.transform.position);
        }

        /// <summary>
        /// Check if the agent has reached his destination
        /// </summary>
        /// <returns></returns>
        public bool DestinationReached()
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if the agents has any destinations
        /// </summary>
        /// <returns></returns>
        public bool HasDestinationPoints()
        {
            return destinationPoints.Count > 0;
        }
    }
}
