using System;
using System.Collections.Generic;
using UnityEngine;

namespace zerog
{
    public class ShipCamera : MonoBehaviour
    {
        public Transform min, max;
        public Transform cameraTransform;
        public Transform pos;

        public float movementSpeed = 1f;
        public float zoomSpeed = 1f;
        float zoom = 0f;

        public Ship playerShip;

        public bool followPlayer = true;

        Vector3 offset;

        void Start()
        {
            pos = transform;
            offset = Vector3.zero;
        }

        void Update()
        {
            updateMouse();

            if (mousePressed)
            {
                pos.position -= offset;
                offset = new Vector3(offset.x - Input.GetAxis("Mouse X") * movementSpeed,
                                                        pos.position.y,
                                                        offset.z - Input.GetAxis("Mouse Y") * movementSpeed);
                //offset += playerShip.bod.velocity;
                pos.position += offset;
            }
            else
                pos.position = playerShip.pos.position + offset;

            cameraTransform.localPosition = Vector3.Slerp(max.localPosition, min.localPosition, zoom);
        }

        bool mousePressed = false;
        void updateMouse()
        {
            float deltaZ = Input.GetAxis("Mouse ScrollWheel");
            zoom += deltaZ * zoomSpeed;
            if (zoom > 1)
                zoom = 1;
            if (zoom < 0)
                zoom = 0;

            if (Input.GetMouseButtonDown(2) && !mousePressed)
            {
                mousePressed = true;
                return;
            }
            if (Input.GetMouseButtonUp(2) && mousePressed)
            {
                mousePressed = false;
                return;
            }
        }
    }
}
