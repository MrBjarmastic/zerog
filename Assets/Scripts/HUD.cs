using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace zerog
{
    public class HUD : MonoBehaviour
    {
        public Ship ship;

        public RectTransform compass;

        public RectTransform velocityCompass;

        void Update()
        {
            compass.localRotation = Quaternion.AngleAxis(ship.pos.eulerAngles.y, new Vector3(0, 0, 1));
            //compass.up = ship.pos.forward;
            velocityCompass.localRotation = Quaternion.AngleAxis(Vector3.Angle(new Vector3(0, 0, 1), ship.bod.velocity.normalized), new Vector3(0, 0, 1));
        }
    }
}
