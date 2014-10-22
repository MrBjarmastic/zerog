using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace zerog
{
    public class HUD : MonoBehaviour
    {

        public RectTransform compass;

        public RectTransform velocityCompass;

        public Text velocityText;
        public Text headingText;

        void Update()
        {
            //compass.localRotation = Quaternion.AngleAxis(ship.pos.eulerAngles.y, new Vector3(0, 0, 1));
            
            //velocityCompass.localRotation = Quaternion.AngleAxis(Vector3.Angle(new Vector3(0, 0, 1), ship.bod.velocity.normalized), new Vector3(0, 0, 1));
        }

        public void UpdateShip(Ship ship)
        {
            compass.forward = ship.pos.forward;
            //velocityCompass.forward = ship.bod.velocity.normalized;
            headingText.text = ship.pos.forward.ToString();
            velocityText.text = ship.bod.velocity.magnitude.ToString();

        }
    }
}
