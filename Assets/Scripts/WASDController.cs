using System;
using System.Collections.Generic;
using UnityEngine;

namespace zerog
{
    [RequireComponent(typeof(Ship))]
    public class WASDController:MonoBehaviour
    {
        Ship ship;
        HUD hud;

        void Start()
        {
            ship = GetComponent<Ship>();
            hud = FindObjectOfType<HUD>();
            if (hud == null)
                Debug.Log("Could not find HUD");
        }

        float thr = 0;
        float rot = 0;
        void FixedUpdate()
        {
            thr = Input.GetAxis("Vertical");
            rot = Input.GetAxis("Horizontal");

            if (thr > 0)
                ship.Thrust(thr);
            else if (thr < 0)
                ship.Stop();
            ship.Turn(rot);

            hud.UpdateShip(ship);
        }


    }
}
