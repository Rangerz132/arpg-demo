using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace rpgStealth
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtual;

        [Header("Zoom Smoothness")]
        [SerializeField] private float damping;
        [SerializeField] private float smoothSpeed;

        [Header("Zoom Clamp")]
        [SerializeField] private float minZoom;
        [SerializeField] private float maxZoom;
        [SerializeField] private float zoom;

        private void Start()
        {
            cinemachineVirtual.m_Lens.OrthographicSize = zoom;
        }

        private void Update()
        {
            HandleZoom();
        }

        private void HandleZoom()
        {
            // Define zoom value based on the mouse scroll delta
            if (Input.mouseScrollDelta.y > 0)
            {
                zoom -= Time.deltaTime * damping;
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                zoom += Time.deltaTime * damping;
            }

            // Set zoom boundaries
            if (zoom <= minZoom)
            {
                zoom = minZoom;
            }
            else if (zoom >= maxZoom)
            {
                zoom = maxZoom;
            }

            cinemachineVirtual.m_Lens.OrthographicSize = Mathf.Lerp(cinemachineVirtual.m_Lens.OrthographicSize, zoom, Time.deltaTime * smoothSpeed);
        }
    }

}

